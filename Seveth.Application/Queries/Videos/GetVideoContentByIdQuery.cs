using MediatR;
using Seventh.Application.Responses;

namespace Seventh.Application.Queries.Videos
{
    public class GetVideoContentByIdQuery : IRequest<GetVideoContentByIdQueryResponse>
    {
        public Guid ServerId { get; set; }
        public Guid VideoId { get; set; }

        protected GetVideoContentByIdQuery()
        { }

        public GetVideoContentByIdQuery(Guid serverId, Guid videoId)
        {
            ServerId = serverId;
            VideoId = videoId;
        }
    }
}