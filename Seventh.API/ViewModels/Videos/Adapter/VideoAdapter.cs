using Seventh.Domain.Entities.Videos;

namespace Seventh.API.ViewModels.Videos.Adapter
{
    public static class VideoAdapter
    {
        public static Video ConvertToVideo(this VideoViewModel viewModel, Guid serverId)
        {
            return new Video(viewModel.Description, viewModel.VideoContent, serverId);
        }
    }
}