using MediatR;

namespace Seventh.Application.Queries.Server
{
    public class ServerIsAvailableQuery : IRequest<bool>
    {
        public Guid ServerId { get; set; }

        protected ServerIsAvailableQuery()
        {
        }

        public ServerIsAvailableQuery(Guid serverId)
        {
            ServerId = serverId;
        }
    }
}