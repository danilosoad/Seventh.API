using Seventh.Domain.Entities.Servers;

namespace Seventh.Domain.Entities.Videos
{
    public class Video : BaseEntity
    {
        public string Description { get; set; }

        public byte[] VideoContent { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid ServerId { get; set; }

        //public Server Server { get; set; }

        protected Video()
        {
        }

        public Video(string description, byte[] videoContent)
        {
            Id = Guid.NewGuid();
            Description = description;
            VideoContent = videoContent;
            CreatedAt = DateTime.Now;
        }
    }
}