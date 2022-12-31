namespace Seventh.Domain.Entities.Servers.Repository
{
    public interface IServerRepository
    {
        Task AddServer(Server server);

        void UpdateServer(Server server);

        Task<Server> GetServerById(Guid id);

        Task<IEnumerable<Server>> GetServers();

        Task DeleteServerById(Guid id);
    }
}