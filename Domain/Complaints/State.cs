namespace Domain.Complaints
{
    public class State
    {
        public Guid Id { get; set; }
        public string StateName { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}