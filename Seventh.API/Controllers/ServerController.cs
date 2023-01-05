using MediatR;
using Microsoft.AspNetCore.Mvc;
using Seventh.API.ViewModels.Servers;
using Seventh.API.ViewModels.Videos;
using Seventh.Application.Commands.Servers;
using Seventh.Application.Commands.Videos;
using Seventh.Application.Queries.Server;
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
            var response = await _mediator.Send(new GetAllServersQuery());

            if (response.Servers.Any())
                return Ok(response.Servers);

            return NoContent();
        }

        [HttpGet]
        [Route("servers/available/{serverId}​")]
        public async Task<IActionResult> IsServerAvailable(Guid serverId)
        {
            var response = await _mediator.Send(new ServerIsAvailableQuery(serverId));

            return Ok(response);
        }

        [HttpGet]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> GetServerbyId(Guid serverId)
        {
            var response = await _mediator.Send(new GetServersByIdQuery(serverId));

            return Ok(response);
        }

        [HttpPost]
        [Route("server")]
        public async Task<IActionResult> CreateServer([FromBody] ServerViewModel viewModel)
        {
            var response = await _mediator.Send(new AddServerCommand(viewModel.Name, viewModel.EnderecoIp, viewModel.PortaIp));

            return Ok(response);
        }

        [HttpPut]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> UpdateServer([FromBody] ServerViewModel viewModel, Guid serverId)
        {
            var response = await _mediator.Send(new UpdateServerCommand(viewModel.Name, viewModel.EnderecoIp, viewModel.PortaIp, serverId));

            return Ok(response);
        }

        [HttpDelete]
        [Route("servers/{serverId}")]
        public async Task<IActionResult> RemoveServer(Guid serverId)
        {
            var response = await _mediator.Send(new DeleteServerCommand(serverId));

            return Ok(response);
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
            var response = await _mediator.Send(new GetVideoByIdQuery(serverId, videoId));

            if (response == null)
                return NoContent();

            return Ok(response);
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