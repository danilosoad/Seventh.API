namespace Seventh.Domain.Entities.Recycles
{
    public class Recycle : BaseEntity
    {
        public string Status { get; set; }

        public string JobId { get; set; }

        public DateTime CreatedAt { get; set; }

        public Recycle(string status, string jobId)
        {
            Status = status;
            JobId = jobId;
            CreatedAt = DateTime.Now;
        }

        protected Recycle()
        {
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }
}