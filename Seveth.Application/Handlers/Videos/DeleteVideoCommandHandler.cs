using MediatR;
using Seventh.Application.Commands.Videos;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Notifications;

namespace Seventh.Application.Handlers.Videos
{
    public class DeleteVideoCommandHandler : IRequestHandler<DeleteVideoCommand, DeleteVideoCommandResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public DeleteVideoCommandHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _serverRepository = serverRepository;
            _notificationContext = notificationContext;
        }

        public async Task<DeleteVideoCommandResponse> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            var response = new DeleteVideoCommandResponse();
            var server = await _serverRepository.GetServerByIdAsync(request.ServerId);

            if (server != null)
            {
                var video = await _serverRepository.GetVideosByIdAsync(request.VideoId);

                if (video != null)
                {
                    _serverRepository.DeleteVideo(video);
                    response.Message = "video deletado com sucesso.";
                    response.VideoId = video.Id;
                    return response;
                }

                _notificationContext.AddNotification("", "video não encontrado");
                return response;
            }
            else
            {
                _notificationContext.AddNotification("", "Server não encontrado.");
                return response;
            }
        }
    }
}