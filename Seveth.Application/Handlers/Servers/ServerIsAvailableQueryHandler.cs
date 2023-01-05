using MediatR;
using Seventh.Application.Queries.Server;
using Seventh.Domain.Entities.Servers.Repository;

namespace Seventh.Application.Handlers.Servers
{
    public class ServerIsAvailableQueryHandler : IRequestHandler<ServerIsAvailableQuery, bool>
    {
        private readonly IServerRepository _serverRepository;

        public ServerIsAvailableQueryHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<bool> Handle(ServerIsAvailableQuery request, CancellationToken cancellationToken)
        {
            var isAvailable = await _serverRepository.IsServerAvailableByIdAsync(request.ServerId);

            return isAvailable;
        }
    }
}