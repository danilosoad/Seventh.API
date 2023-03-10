using Seventh.Domain.Entities.Servers.Validation;
using Seventh.Domain.Entities.Videos;

namespace Seventh.Domain.Entities.Servers
{
    public class Server : BaseEntity
    {
        public string Name { get; set; }
        public string EnderecoIp { get; set; }
        public int PortaIp { get; set; }
        public List<Video> Videos { get; set; }

        protected Server()
        {
        }

        public Server(Guid id, string name, string enderecoIp, int portaIp)
        {
            Id = id;
            Name = name;
            EnderecoIp = enderecoIp;
            PortaIp = portaIp;
        }

        public Server(string name, string enderecoIp, int portaIp)
        {
            Id = Guid.NewGuid();
            Name = name;
            EnderecoIp = enderecoIp;
            PortaIp = portaIp;

            Validate(this, new ServerValidation());
        }

        public void Update(Server server)
        {
            Name = server.Name;
            EnderecoIp = server.EnderecoIp;
            PortaIp = server.PortaIp;
        }

        public void AddVideo(Video video)
        {
            if (Videos == null)
                Videos = new List<Video>();

            Videos.Add(video);
        }
    }
}