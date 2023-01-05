namespace Seventh.Application.DTO
{
    public class ServerDTO
    {
        public string Name { get; set; }

        public string EnderecoIp { get; set; }

        public int PortaIp { get; set; }

        public List<VideoDTO> Videos { get; set; }
    }
}