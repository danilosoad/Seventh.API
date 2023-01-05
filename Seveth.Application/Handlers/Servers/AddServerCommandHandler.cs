using MediatR;
using Seventh.Application.Commands.Servers;
using Seventh.Application.Responses.Server;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Servers
{
    public class AddServerCommandHandler : IRequestHandler<AddServerCommand, AddServerCommandResponse>
    {
        private readonly IServerRepository _serverRepository;

        public AddServerCommandHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<AddServerCommandResponse> Handle(AddServerCommand request, CancellationToken cancellationToken)
        {
            var server = new Server(request.Name, request.EnderecoIp, request.PortaIp);

            await _serverRepository.AddServerAsync(server);

            return new AddServerCommandResponse() { Message = ResponseMessages.AddServerSuccess, Id = server.Id };
        }
    }
}