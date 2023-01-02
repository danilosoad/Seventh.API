using Seventh.Domain.Entities.Videos;

namespace Seventh.Domain.Entities.Servers.Repository
{
    public interface IServerRepository
    {
        #region Server

        Task AddServerAsync(Server server);

        void UpdateServer(Server server);

        Task<Server> GetServerByIdAsync(Guid id);

        Task<bool> IsServerAvailableByIdAsync(Guid id);

        Task<IEnumerable<Server>> GetServersAsync();

        void DeleteServerById(Server server);

        #endregion Server

        #region Video

        //Task AddVideo(Server server);
        Task AddVideoAsync(Video video);

        Task<IEnumerable<Video>> GetVideosByServerIdAsync(Guid Id);

        #endregion Video
    }
}