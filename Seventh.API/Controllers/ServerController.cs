using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seventh.API.ViewModels.Servers;
using Seventh.API.ViewModels.Servers.Adapter;
using Seventh.API.ViewModels.Videos;
using Seventh.Application.Commands.Video;
using Seventh.Application.Queries.Videos;
using Seventh.Application.Services;

namespace Seventh.API.Controllers
{
    [ApiController]
    [Route("api")]
    public class ServerController : ControllerBase
    {
        private readonly IServerService _serverService;
        private readonly IMediator _mediator;

        public ServerController(IServerService serverService, IMediator mediator)
        {
            _serverService = serverService;
            _mediator = mediator;
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
            var response = await _mediator.Send(new AddVideoCommand(viewModel.Description, viewModel.VideoContent, serverId));

            return Ok(response);
        }

        [HttpGet]
        [Route("servers/{serverId}/videos")]
        public async Task<IActionResult> GetVideosByServerId(Guid serverId)
        {
            var response = await _mediator.Send(new GetAllVideosByServerQuery(serverId));

            if (response.Videos.Any())
                return Ok(response.Videos);

            return NoContent();
        }

        [HttpGet]
        [Route("servers/{serverId}/videos/{videoId}​")]
        public async Task<IActionResult> GetVideoById(Guid serverId, Guid videoId)
        {
            var video = await _mediator.Send(new GetVideoByIdQuery(serverId, videoId));

            if (video == null)
                return NoContent();

            return Ok(video);
        }

        [HttpGet]
        [Route("servers/{serverId}/videos/{videoId}/binary​")]
        public async Task<IActionResult> GetVideoContentById(Guid serverId, Guid videoId)
        {
            var response = await _mediator.Send(new GetVideoContentByIdQuery(serverId, videoId));

            if (response.VideoContent == null)
                return NoContent();

            return Ok(response);
        }

        [HttpDelete]
        [Route("servers/{serverId}/videos/{videoId}​")]
        public async Task<IActionResult> DeleteVideoById(Guid serverId, Guid videoId)
        {
            var response = await _mediator.Send(new DeleteVideoCommand(serverId, videoId));

            return Ok(response.Message);
        }

        [HttpGet]
        [Route("recycler/process/{days}​")]
        public async Task<IActionResult> Recycle(int days)
        {
            return Ok();
        }

        [HttpGet]
        [Route("recycler/status​")]
        public async Task<IActionResult> RecycleStatus()
        {
            return Ok();
        }

        #endregion Video
    }
}