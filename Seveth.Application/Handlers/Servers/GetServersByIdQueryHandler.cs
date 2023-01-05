using MediatR;
using Seventh.Application.DTO;
using Seventh.Application.Queries.Server;
using Seventh.Application.Responses.Server;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Videos;
using Seventh.Domain.Notifications;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Servers
{
    public class GetServersByIdQueryHandler : IRequestHandler<GetServersByIdQuery, GetAllServersByIdQueryResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public GetServersByIdQueryHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _serverRepository = serverRepository;
            _notificationContext = notificationContext;
        }

        public async Task<GetAllServersByIdQueryResponse> Handle(GetServersByIdQuery request, CancellationToken cancellationToken)
        {
            var server = await _serverRepository.GetServerByIdAsync(request.ServerId);

            if (server == null)
            {
                _notificationContext.AddNotification("", ResponseMessages.ServerNotFound);
                return new GetAllServersByIdQueryResponse();
            }

            return new GetAllServersByIdQueryResponse()
            {
                Server = new ServerDTO()
                {
                    EnderecoIp = server.EnderecoIp,
                    Name = server.Name,
                    PortaIp = server.PortaIp,
                    Videos = ConvertToVideoDTO(server.Videos)
                }
            };
        }

        private List<VideoDTO> ConvertToVideoDTO(List<Video> videos)
        {
            var videosDTO = new List<VideoDTO>();

            if (videos.Any())
            {
                foreach (var item in videos)
                {
                    videosDTO.Add(new VideoDTO()
                    {
                        CreatedAt = item.CreatedAt,
                        Description = item.Description,
                        ServerId = item.ServerId
                    });
                }
            }

            return videosDTO;
        }
    }
}