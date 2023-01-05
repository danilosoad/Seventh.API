using Seventh.Application.DTO;

namespace Seventh.Application.Responses.Server
{
    public class GetAllServersQueryResponse
    {
        public GetAllServersQueryResponse()
        {
            Servers = new List<ServerDTO>();
        }

        public List<ServerDTO> Servers { get; set; }
    }
}