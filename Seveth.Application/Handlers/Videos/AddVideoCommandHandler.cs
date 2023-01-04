using MediatR;
using Seventh.Application.Commands.Video;
using Seventh.Application.Responses;
using Seventh.Domain.Entities.Servers.Repository;
using Seventh.Domain.Entities.Videos;

namespace Seventh.Application.Handlers.Videos
{
    public class AddVideoCommandHandler : IRequestHandler<AddVideoCommand, AddVideoResponse>
    {
        private readonly IServerRepository _serverRepository;

        public AddVideoCommandHandler(IServerRepository serverRepository)
        {
            _serverRepository = serverRepository;
        }

        public async Task<AddVideoResponse> Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            //add video validation
            var video = new Video(request.Description, request.VideoContent, request.ServerId);
            await _serverRepository.AddVideoAsync(video);

            return new AddVideoResponse() { IdVideo = video.Id, Message = "Video adicionado com sucesso." };
        }
    }
}