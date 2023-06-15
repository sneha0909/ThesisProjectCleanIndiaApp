namespace Domain.Complaints
{
    public class ComplainantLocation
    {
        public Guid Id { get; set; }
        public string ComplainantLocationWardNo { get; set; }
        public string ComplainantLocationHouseNo { get; set; }
        public string ComplainantLocationHouseName { get; set; }
        public string ComplainantLocationLandmark { get; set; }
        public string ComplainantLocationArea { get; set; }
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
  
    }
}