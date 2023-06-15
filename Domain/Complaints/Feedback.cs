namespace Domain
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; }
        public Guid? ComplaintId { get; set; }
        public Complaint? Complaint { get; set; }
    }
}
