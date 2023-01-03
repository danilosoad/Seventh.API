﻿using FluentValidation;
using Seventh.Application.DTO;
using Seventh.Domain.Entities.Servers;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Servers.Validation;
using Seventh.Domain.Entities.Videos;

namespace Seventh.Application.Services
{
    public class ServerService : IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly ServerValidation _validator;

        public ServerService(IServerRepository serverRepository, ServerValidation validator)
        {
            _serverRepository = serverRepository;
            _validator = validator;
        }

        #region Server

        public async Task AddServerAsync(Server server)
        {
            var validator = new ServerValidation();

            await validator.ValidateAndThrowAsync(server);

            await _serverRepository.AddServerAsync(server);
        }

        public async Task<bool> IsServerAvailable(Guid id)
        {
            return await _serverRepository.IsServerAvailableByIdAsync(id);
        }

        public async Task<Server> GetServerByIdAsync(Guid id)
        {
            return await _serverRepository.GetServerByIdAsync(id);
        }

        public async Task<IEnumerable<Server>> GetServersAsync()
        {
            return await _serverRepository.GetServersAsync();
        }

        public async Task RemoveServerAsync(Guid Id)
        {
            var currentServer = await _serverRepository.GetServerByIdAsync(Id);

            if (currentServer != null)
                _serverRepository.DeleteServerById(currentServer);
        }

        public async Task UpdateServerAsync(Server server)
        {
            _validator.ValidateAndThrow(server);

            var currentServer = await _serverRepository.GetServerByIdAsync(server.Id);

            if (currentServer != null)
            {
                currentServer.Update(server);
                _serverRepository.UpdateServer(currentServer);
            }
        }

        #endregion Server

        #region Video

        public async Task AddVideoAsync(Video video, Guid serverId)
        {
            //add validation to video
            var server = await _serverRepository.GetServerByIdAsync(serverId);

            if (server != null)
            {
                //server.AddVideo(video);
                //_serverRepository.UpdateServer(server);
                await _serverRepository.AddVideoAsync(video);
            }
            else
            {
                throw new Exception("servidor não encontrado");
            }
        }

        public async Task<VideoDTO> GetVideoByIdAsync(Guid serverId, Guid videoId)
        {
            var server = await _serverRepository.GetServerByIdAsync(serverId);

            if (server != null)
            {
                var video = await _serverRepository.GetVideosByIdAsync(videoId);

                return new VideoDTO() { CreatedAt = video.CreatedAt, Description = video.Description, ServerId = video.ServerId };
            }

            throw new Exception("servidor não encontrado");
        }

        public async Task<IEnumerable<Video>> GetVideosAsync(Guid serverId)
        {
            var server = await _serverRepository.GetServerByIdAsync(serverId);

            if (server != null)
                return await _serverRepository.GetVideosByServerIdAsync(server.Id);

            return await Task.FromResult(Enumerable.Empty<Video>());
        }

        public async Task<byte[]> GetVideoContent(Guid serverId, Guid videoId)
        {
            var server = await _serverRepository.GetServerByIdAsync(serverId);

            if (server != null)
            {
                var video = await _serverRepository.GetVideosByIdAsync(videoId);

                if (video != null)
                    return await _serverRepository.GetVideoContentAsync(videoId);
                else
                    throw new Exception("video não encontrado");
            }
            else
                throw new Exception("servidor não encontrado");
        }

        public async Task RemoveVideoAsync(Guid serverId, Guid videoId)
        {
            var server = await _serverRepository.GetServerByIdAsync(serverId);

            if (server != null)
            {
                var video = await _serverRepository.GetVideosByIdAsync(videoId);

                if (video != null)
                    _serverRepository.DeleteVideo(video);
                else
                    throw new Exception("video não encontrado");
            }
            else
                throw new Exception("servidor não encontrado");
        }

        #endregion Video
    }
}