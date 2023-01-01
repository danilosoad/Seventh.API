using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Videos;

namespace Seventh.Application.Services
{
    public interface IServerService
    {
        #region Server

        Task AddServerAsync(Server server);

        Task<IEnumerable<Server>> GetServersAsync();

        Task<Server> GetServerByIdAsync(Guid id);

        Task UpdateServerAsync(Server server);

        Task RemoveServerAsync(Guid Id);

        #endregion Server

        #region Videos

        Task AddVideoAsync(Video video, Guid serverId);

        Task<IEnumerable<Video>> GetVideosAsync(Guid serverId);

        Task<Server> GetVideoByIdAsync(Guid id);

        //Task UpdateServerAsync(Server server);

        Task RemoveVideoAsync(Guid Id);

        #endregion Videos
    }
}