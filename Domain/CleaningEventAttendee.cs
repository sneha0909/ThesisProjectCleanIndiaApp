namespace Domain
{
    public class CleaningEventAttendee
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public Guid CleaningEventId { get; set; }
        public CleaningEvent CleaningEvent { get; set; }
        public bool IsHost { get; set; }

        
    }
}