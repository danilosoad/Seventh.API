﻿using Microsoft.AspNetCore.Mvc;
using Seventh.API.ViewModels.Servers;
using Seventh.API.ViewModels.Servers.Adapter;
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

        [HttpGet]
        [Route("{serverId}")]
        public async Task<IActionResult> GetVideosByServerId(Guid serverId)
        {
            //var video = await _serverService.GetServerByIdAsync(videoId);

            //if (server == null)
            //    return NoContent();

            return Ok();
        }

        [HttpGet]
        [Route("{videoId}")]
        public async Task<IActionResult> GetVideoById(Guid videoId)
        {
            //var video = await _serverService.GetServerByIdAsync(videoId);

            //if (server == null)
            //    return NoContent();

            return Ok();
        }

        [HttpGet]
        [Route("{videoId}/content")]
        public async Task<IActionResult> GetVideoContentById(Guid videoId)
        {
            //var video = await _serverService.GetServerByIdAsync(videoId);

            //if (server == null)
            //    return NoContent();

            return Ok();
        }

        [HttpDelete]
        [Route("{videoId}")]
        public async Task<IActionResult> DeleteVideoById(Guid videoId)
        {
            //var video = await _serverService.GetServerByIdAsync(videoId);

            //if (server == null)
            //    return NoContent();

            return Ok();
        }

        #endregion Video
    }
}