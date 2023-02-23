

using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string ComplainantName { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public string  MunicipalCorporation { get; set; }

        public virtual string PhoneNumber { get; set; }

        public ICollection<Photo> Photos { get; set; }
        
    }
    
}