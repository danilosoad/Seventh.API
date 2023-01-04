using MediatR;
using Seventh.Application.Responses;

namespace Seventh.Application.Queries.Videos
{
    public class GetVideoByIdQuery : IRequest<GetVideoByIdResponse>
    {
        public Guid VideoId { get; set; }
        public Guid ServerId { get; set; }

        protected GetVideoByIdQuery()
        { }

        public GetVideoByIdQuery(Guid videoId, Guid serverId)
        {
            VideoId = videoId;
            ServerId = serverId;
        }
    }
}