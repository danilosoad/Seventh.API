using Seventh.Domain.Entities.Servers;

namespace Seventh.Application.Services
{
    public interface IVideoService
    {
        Task AddVideoAsync(Server server);

        //Task<IEnumerable<Server>> GetServersAsync();

        Task<Server> GetVideoByIdAsync(Guid id);

        //Task UpdateServerAsync(Server server);

        Task RemoveServerAsync(Guid Id);
    }
}