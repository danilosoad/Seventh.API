using Microsoft.EntityFrameworkCore;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;
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

        public async Task AddServer(Server server)
        {
            await _context.AddAsync(server);
            await _context.SaveChangesAsync();
        }

        public Task DeleteServerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Server> GetServerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Server>> GetServers()
        {
            return await _context.Servers.AsQueryable().AsNoTracking().ToListAsync();
        }

        public void UpdateServer(Server server)
        {
            throw new NotImplementedException();
        }
    }
}