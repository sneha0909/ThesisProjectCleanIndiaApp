using Application.Core;

namespace Application.CleaningEvents
{
    public class CleaningEventParams : PagingParams
    {
        public bool IsGoing { get; set; }

        public bool IsHost { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;

    }
}