using MediatR;
using Seventh.Application.Commands.Videos;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Videos;
using Seventh.Domain.Notifications;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Videos
{
    public class AddVideoCommandHandler : IRequestHandler<AddVideoCommand, AddVideoCommandResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public AddVideoCommandHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _serverRepository = serverRepository;
            _notificationContext = notificationContext;
        }

        public async Task<AddVideoCommandResponse> Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            var currentServer = await _serverRepository.GetServerByIdAsync(request.ServerId);

            if (currentServer == null)
            {
                _notificationContext.AddNotification("", ResponseMessages.ServerNotFound);
                return new AddVideoCommandResponse();
            }

            var video = new Video(request.Description, request.VideoContent, request.ServerId);

            //Para testar o range de dias
            //var video = new Video(request.Description, request.VideoContent, request.ServerId, DateTime.Now.AddDays(-20));

            if (video.Invalid)
            {
                _notificationContext.AddNotifications(video.ValidationResult);
                return new AddVideoCommandResponse();
            }

            await _serverRepository.AddVideoAsync(video);

            return new AddVideoCommandResponse() { IdVideo = video.Id, Message = "Video adicionado com sucesso." };
        }
    }
}