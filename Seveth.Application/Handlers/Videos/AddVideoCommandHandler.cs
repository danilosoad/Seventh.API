using MediatR;
using Seventh.Application.Commands.Video;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Videos;
using Seventh.Domain.Notifications;

namespace Seventh.Application.Handlers.Videos
{
    public class AddVideoCommandHandler : IRequestHandler<AddVideoCommand, AddVideoResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public AddVideoCommandHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _serverRepository = serverRepository;
            _notificationContext = notificationContext;
        }

        public async Task<AddVideoResponse> Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            //add video validation
            var video = new Video(request.Description, request.VideoContent, request.ServerId);

            if (video.Invalid)
            {
                _notificationContext.AddNotifications(video.ValidationResult);
                return new AddVideoResponse();
            }

            await _serverRepository.AddVideoAsync(video);

            return new AddVideoResponse() { IdVideo = video.Id, Message = "Video adicionado com sucesso." };
        }
    }
}