namespace Domain.Complaints
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Pincode { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public ComplaintLocation ComplaintLocation { get; set; }
        public ComplainantLocation ComplainantLocation { get; set; }
        public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    }
}
