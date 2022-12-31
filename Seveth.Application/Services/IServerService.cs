using Seventh.Domain.Entities.Servers;

namespace Seventh.Application.Services
{
    public interface IServerService
    {
        Task AddServer(Server server);

        Task<IEnumerable<Server>> GetServers();

        Task<Server> GetServerById(Guid id);

        void UpdateServer(Server server);

        Task RemoveServer(Guid Id);
    }
}