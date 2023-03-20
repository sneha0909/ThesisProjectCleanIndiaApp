using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class CreateComplaintDto
    {
        public IFormFile PictureUrl { get; set; }
    }
}
