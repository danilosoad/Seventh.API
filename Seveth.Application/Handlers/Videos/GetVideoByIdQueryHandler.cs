using MediatR;
using Seventh.Application.DTO;
using Seventh.Application.Queries.Videos;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;

namespace Seventh.Application.Handlers.Videos
{
    public class GetVideoByIdQueryHandler : IRequestHandler<GetVideoByIdQuery, GetVideoByIdQueryResponse>
    {
        private readonly IServerRepository _serverRepository;

        public GetVideoByIdQueryHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<GetVideoByIdQueryResponse> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
        {
            //add validacao
            var response = new GetVideoByIdQueryResponse();

            var server = _serverRepository.GetServerByIdAsync(request.ServerId);

            if (server != null)
            {
                var video = await _serverRepository.GetVideosByIdAsync(request.VideoId);

                if (video != null)
                {
                    response.Video = new VideoDTO() { CreatedAt = video.CreatedAt, Description = video.Description, ServerId = video.ServerId };

                    return response;
                }
            }

            return response;
        }
    }
}