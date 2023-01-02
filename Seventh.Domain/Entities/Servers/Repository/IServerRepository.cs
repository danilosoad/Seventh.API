using Seventh.Domain.Entities.Videos;

namespace Seventh.Domain.Entities.Servers.Repository
{
    public interface IServerRepository
    {
        #region Server

        Task AddServer(Server server);

        void UpdateServer(Server server);

        Task<Server> GetServerById(Guid id);

        Task<IEnumerable<Server>> GetServers();

        void DeleteServerById(Server server);

        #endregion Server

        #region Video
        //Task AddVideo(Server server);
        Task AddVideo(Video video);
        Task<IEnumerable<Video>> GetVideosByServerId(Guid Id);

        #endregion Video
    }
}