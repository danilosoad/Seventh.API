using MediatR;
using Seventh.Application.Responses.Server;

namespace Seventh.Application.Queries.Server
{
    public class GetServersByIdQuery : IRequest<GetAllServersByIdQueryResponse>
    {
        public Guid ServerId { get; set; }

        protected GetServersByIdQuery()
        { }

        public GetServersByIdQuery(Guid serverId)
        {
            ServerId = serverId;
        }
    }
}