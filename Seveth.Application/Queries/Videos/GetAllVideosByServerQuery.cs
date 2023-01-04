using MediatR;
using Seventh.Application.Responses;

namespace Seventh.Application.Queries.Videos
{
    public class GetAllVideosByServerQuery : IRequest<GetAllVideosByServerQueryResponse>
    {
        public Guid ServerId { get; set; }

        protected GetAllVideosByServerQuery()
        {
        }

        public GetAllVideosByServerQuery(Guid serverId)
        {
            ServerId = serverId;
        }
    }
}