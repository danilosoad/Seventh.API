using Seventh.Domain.Entities.Servers;

namespace Seventh.Application.Services
{
    public interface IServerService
    {
        Task AddServerAsync(Server server);

        Task<IEnumerable<Server>> GetServersAsync();

        Task<Server> GetServerByIdAsync(Guid id);

        Task UpdateServerAsync(Server server);

        Task RemoveServerAsync(Guid Id);
    }
}