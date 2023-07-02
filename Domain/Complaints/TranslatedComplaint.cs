using Domain.Complaints.Enums;
using System.Text.Json.Serialization;

namespace Domain.Complaints
{
    public class TranslatedComplaint
    {
        public Guid Id { get; set; }
        public string TranslatedDescription { get; set; }
        public string TranslatedComplainantName { get; set; }
        public AddressTranslation AddressTranslation { get; set; }
        public string FeedbackMessage { get; set; }
        public Guid ComplaintId { get; set; }        
        public Complaint Complaint { get; set; }
        public ComplaintLanguage Language { get; set; }

    }
}
