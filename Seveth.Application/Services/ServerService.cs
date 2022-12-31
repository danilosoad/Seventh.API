using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;

namespace Seventh.Application.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;

        public ServerService(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task AddServer(Server server)
        {
            await _serverRepository.AddServer(server);
        }

        public async Task<Server> GetServerById(Guid id)
        {
            return await _serverRepository.GetServerById(id);
        }

        public async Task<IEnumerable<Server>> GetServers()
        {
            return await _serverRepository.GetServers();
        }

        public async Task RemoveServer(Guid Id)
        {
            await _serverRepository.DeleteServerById(Id);
        }

        public void UpdateServer(Server server)
        {
            _serverRepository.UpdateServer(server);
        }
    }
}