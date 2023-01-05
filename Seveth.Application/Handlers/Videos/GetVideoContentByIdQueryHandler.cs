using MediatR;
using Seventh.Application.Queries.Videos;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Notifications;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Videos
{
    public class GetVideoContentByIdQueryHandler : IRequestHandler<GetVideoContentByIdQuery, GetVideoContentByIdQueryResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public GetVideoContentByIdQueryHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
            _serverRepository = serverRepository;
        }

        public async Task<GetVideoContentByIdQueryResponse> Handle(GetVideoContentByIdQuery request, CancellationToken cancellationToken)
        {
            var server = await _serverRepository.GetServerByIdAsync(request.ServerId);

            if (server == null)
            {
                _notificationContext.AddNotification("", ResponseMessages.ServerNotFound);
                return new GetVideoContentByIdQueryResponse();
            }
            var video = await _serverRepository.GetVideosByIdAsync(request.VideoId);
            if (video == null)
            {
                _notificationContext.AddNotification("", ResponseMessages.VideoNotFound);
                return new GetVideoContentByIdQueryResponse();
            }

            return new GetVideoContentByIdQueryResponse() { VideoContent = video.VideoContent };
        }
    }
}