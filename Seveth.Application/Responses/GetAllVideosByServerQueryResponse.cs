using Seventh.Application.DTO;

namespace Seventh.Application.Responses
{
    public class GetAllVideosByServerQueryResponse
    {
        public GetAllVideosByServerQueryResponse()
        {
            Videos = new List<VideoDTO>();
        }

        public List<VideoDTO> Videos { get; set; }
    }
}