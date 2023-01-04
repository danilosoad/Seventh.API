using MediatR;
using Seventh.Application.Responses;

namespace Seventh.Application.Commands.Video
{
    public class DeleteVideoCommand : IRequest<DeleteVideoCommandResponse>
    {
        public Guid ServerId { get; set; }
        public Guid VideoId { get; set; }

        protected DeleteVideoCommand()
        {

        }

        public DeleteVideoCommand(Guid serverId, Guid videoId)
        {
            ServerId = serverId;
            VideoId = videoId;
        }
    }
}