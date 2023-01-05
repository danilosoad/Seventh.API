using MediatR;
using Seventh.Application.Responses.Server;

namespace Seventh.Application.Commands.Servers
{
    public class UpdateServerCommand : IRequest<UpdateServerCommandResponse>
    {
        public string Name { get; set; }

        public string EnderecoIp { get; set; }

        public int PortaIp { get; set; }

        public Guid ServerId { get; set; }

        protected UpdateServerCommand()
        { }

        public UpdateServerCommand(string name, string enderecoIp, int portaIp, Guid serverId)
        {
            Name = name;
            EnderecoIp = enderecoIp;
            PortaIp = portaIp;
            ServerId = serverId;
        }
    }
}