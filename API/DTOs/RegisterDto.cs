using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string ComplainantName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage ="Password must be complex")]
        public string Password { get; set; }

        [Required]
        public string State { get; set; }
       
        [Required] 
        public string District { get; set; }

        [Required]
        public string MunicipalCorporation { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

    }
}