using MediatR;
using Seventh.Application.Commands.Servers;
using Seventh.Application.Responses.Server;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Notifications;
using Seventh.Domain.Resources;

namespace Seventh.Application.Handlers.Servers
{
    public class DeleteServerCommandHandler : IRequestHandler<DeleteServerCommand, DeleteServerCommandResponse>
    {
        private readonly IServerRepository _serverRepository;
        private readonly NotificationContext _notificationContext;

        public DeleteServerCommandHandler(IServerRepository serverRepository, NotificationContext notificationContext)
        {
            _serverRepository = serverRepository;
            _notificationContext = notificationContext;
        }

        public async Task<DeleteServerCommandResponse> Handle(DeleteServerCommand request, CancellationToken cancellationToken)
        {
            var currentServer = await _serverRepository.GetServerByIdAsync(request.ServerId);

            if (currentServer == null)
            {
                _notificationContext.AddNotification("", ResponseMessages.ServerNotFound);
                return new DeleteServerCommandResponse();
            }

            _serverRepository.DeleteServerById(currentServer);
            return new DeleteServerCommandResponse() { Id = currentServer.Id, Message = ResponseMessages.RemoveServerSuccess };
        }
    }
}