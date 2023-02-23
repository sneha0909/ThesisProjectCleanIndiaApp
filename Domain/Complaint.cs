namespace Domain
{
    public class Complaint
    {
        public Guid Id { get; set; }

        public string ComplainantName { get; set; }

        public DateTime DateOfComplaint { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public string MunicipalCorporation { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }
    }
}