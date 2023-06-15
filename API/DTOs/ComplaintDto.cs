using Domain.Enums;

namespace API.DTOs
{
    public class ComplaintDto
    {
        public ComplaintType ComplaintType { get; set; }
        public ComplaintSubType ComplaintSubType { get; set; }
        public string Description { get; set; }
        public string ComplaintLocationWardNo { get; set; }
        public string ComplaintLocationArea { get; set; }
        public string ComplaintLocationLandmark { get; set; }
        public string ComplainantName { get; set; }
        public string ComplainantLocationWardNo { get; set; }
        public string ComplainantLocationHouseNo { get; set; }
        public string ComplainantLocationHouseName { get; set; }
        public string ComplainantLocationArea { get; set; }
        public string ComplainantLocationLandmark { get; set; }  
        public string Pincode { get; set; }
        public Guid selectedState { get; set; }
        public Guid selectedCity { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 
        public IFormFile PictureUrl { get; set; }
    }
}
