using MediatR;
using Seventh.Application.Commands.Servers;
using Seventh.Application.Responses.Server;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Notifications;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Servers
{
    public class UpdateServerCommandHandler : IRequestHandler<UpdateServerCommand, UpdateServerCommandResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public UpdateServerCommandHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _serverRepository = serverRepository;
            _notificationContext = notificationContext;
        }

        public async Task<UpdateServerCommandResponse> Handle(UpdateServerCommand request, CancellationToken cancellationToken)
        {
            var currentServer = await _serverRepository.GetServerByIdAsync(request.ServerId);

            if (currentServer == null)
            {
                _notificationContext.AddNotification("", ResponseMessages.ServerNotFound);
                return new UpdateServerCommandResponse();
            }
            var server = new Server(request.Name, request.EnderecoIp, request.PortaIp);
            currentServer.Update(server);
            _serverRepository.UpdateServer(currentServer);

            return new UpdateServerCommandResponse() { Id = currentServer.Id, Message = ResponseMessages.UpdateServerSuccess };
        }
    }
}