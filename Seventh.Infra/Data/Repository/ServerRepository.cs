﻿using Microsoft.EntityFrameworkCore;
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

        public void DeleteServerById(Server server)
        {
            _context.Servers.Remove(server);
            _context.SaveChanges();
        }

        public async Task<Server> GetServerById(Guid id)
        {
            return await _context.Servers.AsQueryable().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Server>> GetServers()
        {
            return await _context.Servers.AsQueryable().AsNoTracking().ToListAsync();
        }

        public void UpdateServer(Server server)
        {
            _context.Servers.Update(server);
            _context.SaveChanges();
        }
    }
}