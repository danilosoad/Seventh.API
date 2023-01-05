using MediatR;
using Seventh.Application.Responses.Server;

namespace Seventh.Application.Commands.Servers
{
    public class AddServerCommand : IRequest<AddServerCommandResponse>
    {
        public string Name { get; set; }

        public string EnderecoIp { get; set; }

        public int PortaIp { get; set; }

        protected AddServerCommand()
        {
        }

        public AddServerCommand(string name, string enderecoIp, int portaIp)
        {
            Name = name;
            EnderecoIp = enderecoIp;
            PortaIp = portaIp;
        }
    }
}