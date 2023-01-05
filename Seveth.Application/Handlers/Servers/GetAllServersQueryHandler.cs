using MediatR;
using Seventh.Application.DTO;
using Seventh.Application.Queries.Server;
using Seventh.Application.Responses.Server;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Videos;

namespace Seventh.Application.Handlers.Servers
{
    public class GetAllServersQueryHandler : IRequestHandler<GetAllServersQuery, GetAllServersQueryResponse>
    {
        private readonly IServerRepository _serverRepository;

        public GetAllServersQueryHandler(IMediator mediator, IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<GetAllServersQueryResponse> Handle(GetAllServersQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllServersQueryResponse();
            var servers = await _serverRepository.GetServersAsync();

            if (servers.Any())
            {
                foreach (var item in servers)
                {
                    response.Servers.Add(new ServerDTO()
                    {
                        EnderecoIp = item.EnderecoIp,
                        Name = item.Name,
                        PortaIp = item.PortaIp,
                        Videos = ConvertToVideoDTO(item.Videos)
                    });
                }
            }

            return response;
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