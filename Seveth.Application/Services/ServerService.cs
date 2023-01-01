using FluentValidation;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Servers.Validation;

namespace Seventh.Application.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly ServerValidation _validator;

        public ServerService(IServerRepository serverRepository, ServerValidation validator)
        {
            _serverRepository = serverRepository;
            _validator = validator;
        }

        public async Task AddServerAsync(Server server)
        {
            var validator = new ServerValidation();

            await validator.ValidateAndThrowAsync(server);

            await _serverRepository.AddServer(server);
        }

        public async Task<Server> GetServerByIdAsync(Guid id)
        {
            return await _serverRepository.GetServerById(id);
        }

        public async Task<IEnumerable<Server>> GetServersAsync()
        {
            return await _serverRepository.GetServers();
        }

        public async Task RemoveServerAsync(Guid Id)
        {
            await _serverRepository.DeleteServerById(Id);
        }

        public async Task UpdateServerAsync(Server server)
        {
            _validator.ValidateAndThrow(server);
            _serverRepository.UpdateServer(server);
        }
    }
}