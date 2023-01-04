using MediatR;
using Seventh.Application.DTO;
using Seventh.Application.Queries.Videos;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;

namespace Seventh.Application.Handlers.Videos
{
    public class GetAllVideosByServerQueryHandler : IRequestHandler<GetAllVideosByServerQuery, GetAllVideosByServerQueryResponse>
    {
        private readonly IServerRepository _serverRepository;

        public GetAllVideosByServerQueryHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<GetAllVideosByServerQueryResponse> Handle(GetAllVideosByServerQuery request, CancellationToken cancellationToken)
        {
            var response = new GetAllVideosByServerQueryResponse();
            var videos = await _serverRepository.GetVideosByServerIdAsync(request.ServerId);

            if (videos.Any())
            {
                foreach (var item in videos)
                {
                    response.Videos.Add(new VideoDTO() { CreatedAt = item.CreatedAt, Description = item.Description, ServerId = item.ServerId });
                }
                return response;
            }

            return response;
        }
    }
}