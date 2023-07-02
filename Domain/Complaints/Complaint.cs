using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Complaints;
using Domain.Enums;

namespace Domain
{
    public class Complaint
    {
        public Guid Id { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ComplaintType ComplaintType { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ComplaintSubType ComplaintSubType { get; set; }
        public string Description { get; set; }
        public string ComplainantName { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }  
        public string PhotoUrl { get; set; }
        public string PublicId { get; set; }
        public ComplaintStatus ComplaintStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<TranslatedComplaint> TranslatedComplaints { get; set; } = new List<TranslatedComplaint>();   
        public Feedback? Feedback { get; set; }
    }
}
