using MediatR;
using Seventh.Application.Responses.Server;

namespace Seventh.Application.Commands.Servers
{
    public class DeleteServerCommand : IRequest<DeleteServerCommandResponse>
    {
        public Guid ServerId { get; set; }

        protected DeleteServerCommand()
        {
        }

        public DeleteServerCommand(Guid serverId)
        {
            ServerId = serverId;
        }
    }
}