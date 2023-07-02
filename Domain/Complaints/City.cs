namespace Domain.Complaints
{
    public class City
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}