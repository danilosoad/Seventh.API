namespace Seventh.Domain.Entities.Servers
{
    public class Server : BaseEntity
    {
        public string Name { get; set; }
        public string EnderecoIp { get; set; }
        public int PortaIp { get; set; }

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
        }
    }
}