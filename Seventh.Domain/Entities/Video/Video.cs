namespace Seventh.Domain.Entities.Video
{
    public class Video : BaseEntity
    {
        public string Description { get; set; }
        public byte[] VideoContent { get; set; }
        public Guid ServerId { get; set; }
        public DateTime CreatedAt { get; set; }

        protected Video()
        {
        }

        public Video(string description, byte[] videoContent, Guid serverId, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Description = description;
            VideoContent = videoContent;
            ServerId = serverId;
            CreatedAt = DateTime.Now;
        }
    }
}