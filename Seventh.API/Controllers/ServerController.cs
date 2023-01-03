using Microsoft.AspNetCore.Mvc;
using Seventh.API.ViewModels.Servers;
using Seventh.API.ViewModels.Servers.Adapter;
using Seventh.API.ViewModels.Videos;
using Seventh.API.ViewModels.Videos.Adapter;
using Seventh.Application.Services;

namespace Seventh.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ServerController : ControllerBase
    {
        private readonly IServerService _serverService;

        public ServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        #region Server

        [HttpGet]
        [Route("servers")]
        public async Task<IActionResult> GetServers()
        {
            var servers = await _serverService.GetServersAsync();

            if (servers.Any())
                return Ok(servers.ToList());

            return NoContent();
        }

        [HttpGet]
        [Route("servers/available/{serverId}​")]
        public async Task<IActionResult> IsServerAvailable(Guid serverId)
        {
            var isAvailable = await _serverService.IsServerAvailable(serverId);

            return Ok(isAvailable);
        }

        [HttpGet]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> GetServerbyId(Guid serverId)
        {
            var server = await _serverService.GetServerByIdAsync(serverId);

            if (server == null)
                return NoContent();

            return Ok(server);
        }

        [HttpPost]
        [Route("server")]
        public async Task<IActionResult> CreateServer([FromBody] ServerViewModel viewModel)
        {
            var server = viewModel.ConvertToServer();
            await _serverService.AddServerAsync(server);

            return Ok(server.Id);
        }

        [HttpPut]
        [Route("{serverId}")]
        public async Task<IActionResult> UpdateServer([FromBody] ServerViewModel viewModel, Guid serverId)
        {
            var server = viewModel.ConvertToServer(serverId);
            await _serverService.UpdateServerAsync(server);
            return Ok();
        }

        [HttpDelete]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> RemoveServer(Guid serverId)
        {
            await _serverService.RemoveServerAsync(serverId);
            return Ok();
        }

        #endregion Server

        #region Video

        [HttpPost]
        [Route("servers/{serverId}/videos")]
        public async Task<IActionResult> AddVideo([FromBody] VideoViewModel viewModel, Guid serverId)
        {
            var video = viewModel.ConvertToVideo(serverId);
            await _serverService.AddVideoAsync(video, serverId);

            return Ok();
        }

        [HttpGet]
        [Route("servers/{serverId}/videos")]
        public async Task<IActionResult> GetVideosByServerId(Guid serverId)
        {
            var videos = await _serverService.GetVideosAsync(serverId);

            if (videos.Any())
                return Ok(videos);

            return NoContent();
        }

        [HttpGet]
        [Route("servers/{serverId}/videos/{videoId}​")]
        public async Task<IActionResult> GetVideoById(Guid serverId, Guid videoId)
        {
            var video = await _serverService.GetVideoByIdAsync(serverId, videoId);

            if (video == null)
                return NoContent();

            return Ok(video);
        }

        [HttpGet]
        [Route("servers/{serverId}/videos/{videoId}/binary​")]
        public async Task<IActionResult> GetVideoContentById(Guid serverId, Guid videoId)
        {
            var videoBinaryContent = await _serverService.GetVideoContent(serverId, videoId);

            if (videoBinaryContent == null)
                return NoContent();

            return Ok(videoBinaryContent);
        }

        [HttpDelete]
        [Route("servers/{serverId}/videos/{videoId}​")]
        public async Task<IActionResult> DeleteVideoById(Guid serverId, Guid videoId)
        {
            await _serverService.RemoveVideoAsync(serverId, videoId);

            return Ok();
        }

        #endregion Video
    }
}