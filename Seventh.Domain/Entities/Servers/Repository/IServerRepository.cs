using Seventh.Domain.Entities.Recycles;
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

        Task AddVideoAsync(Video video);

        Task<IEnumerable<Video>> GetVideosByServerIdAsync(Guid Id);

        Task<Video> GetVideosByIdAsync(Guid Id);

        Task<byte[]> GetVideoContentAsync(Guid id);

        void DeleteVideo(Video video);

        void RecycleVideos(int days);

        Task AddRecycleAsync(Recycle recycle);

        Task<Recycle> GetRecycleByJobIdAsync(string Id);

        Task<Recycle> GetRecycleStatusAsync();

        void UpdateStatusRecycle(Recycle recycle);

        #endregion Video
    }
}