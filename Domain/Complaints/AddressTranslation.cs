using System.Text.Json.Serialization;
using Domain.Complaints.Enums;

namespace Domain.Complaints
{
    public class AddressTranslation
    {
        public Guid Id { get; set; }
         public string TranslatedComplaintLocationArea { get; set; }
         public string TranslatedComplaintLocationLandmark { get; set; }
         public string TranslatedComplainantLocationHouseName { get; set; }
         public string TranslatedComplainantLocationLandmark { get; set; }
         public string TranslatedComplainantLocationArea { get; set; }
         
         [JsonIgnore]
         public Guid TranslatedComplaintId { get; set; }
         public TranslatedComplaint TranslatedComplaint { get; set; }
         public ComplaintLanguage Language { get; set; }

    }
}