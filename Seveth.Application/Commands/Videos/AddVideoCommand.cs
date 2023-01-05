using MediatR;
using Seventh.Application.Responses;

namespace Seventh.Application.Commands.Videos
{
    public class AddVideoCommand : IRequest<AddVideoCommandResponse>
    {
        public string Description { get; set; }

        public byte[] VideoContent { get; set; }

        public Guid ServerId { get; set; }

        protected AddVideoCommand()
        {
        }

        public AddVideoCommand(string description, byte[] videoContent, Guid serverId)
        {
            Description = description;
            VideoContent = videoContent;
            ServerId = serverId;
        }
    }
}