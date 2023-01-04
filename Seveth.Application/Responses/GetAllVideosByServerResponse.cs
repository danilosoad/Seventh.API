using Seventh.Application.DTO;

namespace Seventh.Application.Responses
{
    public class GetAllVideosByServerResponse
    {
        public GetAllVideosByServerResponse()
        {
            Videos = new List<VideoDTO>();
        }

        public List<VideoDTO> Videos { get; set; }
    }
}