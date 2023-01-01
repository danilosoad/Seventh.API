namespace Seventh.Domain.Entities.Video
{
    public class Video : BaseEntity
    {
        public string Description { get; set; }
        public byte[] VideoContent { get; set; }
        public Guid ServerId { get; set; }
    }
}