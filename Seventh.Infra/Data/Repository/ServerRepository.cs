using Microsoft.EntityFrameworkCore;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Videos;
using Seventh.Infra.Data.DataContext;

namespace Seventh.Infra.Data.Repository
{
    public class ServerRepository : IServerRepository
    {
        private readonly Context _context;

        public ServerRepository(Context context)
        {
            _context = context;
        }

        public async Task AddServerAsync(Server server)
        {
            await _context.AddAsync(server);
            await _context.SaveChangesAsync();
        }

        public void DeleteServerById(Server server)
        {
            _context.Servers.Remove(server);
            _context.SaveChanges();
        }

        public async Task<bool> IsServerAvailableByIdAsync(Guid id)
        {
            return await _context.Servers.AnyAsync(x => x.Id == id);
        }

        public async Task<Server> GetServerByIdAsync(Guid id)
        {
            return await _context.Servers.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Server>> GetServersAsync()
        {
            return await _context.Servers.AsQueryable()
                                         .AsNoTracking()
                                         .Include(x => x.Videos)
                                         .ToListAsync();
        }

        public void UpdateServer(Server server)
        {
            _context.Servers.Update(server);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Video>> GetVideosByServerIdAsync(Guid Id)
        {
            var server = await _context.Servers
                                        .AsQueryable()
                                        .AsNoTracking()
                                        .Include(x => x.Videos)
                                        .FirstOrDefaultAsync(x => x.Id == Id);

            return server?.Videos ?? Enumerable.Empty<Video>();
        }

        public async Task<Video> GetVideosByIdAsync(Guid Id)
        {
            return await _context.Videos.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<byte[]> GetVideoContentAsync(Guid id)
        {
            var video = await _context.Videos.AsQueryable().AsNoTracking().FirstOrDefaultAsync();

            return video.VideoContent;
        }

        public async Task AddVideoAsync(Video video)
        {
            await _context.AddAsync(video);
            await _context.SaveChangesAsync();
        }

        public void DeleteVideo(Video video)
        {
            _context.Videos.Remove(video);
            _context.SaveChanges();
        }
    }
}