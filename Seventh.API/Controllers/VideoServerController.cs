using Microsoft.AspNetCore.Mvc;
using Seventh.API.ViewModels.Servers;
using Seventh.API.ViewModels.Servers.Adapter;
using Seventh.Application.Services;

namespace Seventh.API.Controllers
{
    [ApiController]
    [Route("api/servers")]
    public class VideoServerController : ControllerBase
    {
        private readonly IServerService _serverService;

        public VideoServerController(IServerService serverService)
        {
            _serverService = serverService;
        }

        [HttpGet]
        public async Task<IActionResult> GetServers()
        {
            var servers = await _serverService.GetServersAsync();

            if (servers.Any())
                return Ok(servers.ToList());

            return NoContent();
        }

        [HttpGet]
        [Route("{serverId}")]
        public async Task<IActionResult> GetServerbyId(Guid serverId)
        {
            var server = await _serverService.GetServerByIdAsync(serverId);

            if (server == null)
                return NoContent();

            return Ok(server);
        }

        [HttpPost]
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
        [Route("{serverId}")]
        public async Task<IActionResult> RemoveServer(Guid serverId)
        {
            await _serverService.RemoveServerAsync(serverId);
            return Ok();
        }
    }
}