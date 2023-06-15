namespace Domain.Complaints
{
    public class ComplaintLocation
    {
         public Guid Id { get; set; }
         public string ComplaintLocationWardNo { get; set; }
         public string ComplaintLocationArea { get; set; }
         public string ComplaintLocationLandmark { get; set; }
         public Guid AddressId { get; set; }
         public Address Address { get; set; }
        
    }
}