using Application.Photos;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IComplaintPhotoAccessor
    {
       Task<PhotoUploadResult> AddPhototoComplaint(IFormFile file);
       Task<string> DeletePhototoComplaint(string publicId);
    }
}