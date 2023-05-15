using Application.Core;

namespace Application.Complaints
{
    public class ComplaintParams : PagingParams
    {
        public string ComplaintStatus { get; set; }

        //public DateTime StartDate { get; set; } = DateTime.UtcNow;
    }
}