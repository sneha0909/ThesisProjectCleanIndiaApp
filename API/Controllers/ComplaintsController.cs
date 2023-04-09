using API.DTOs;
using API.Services;
using Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Application.Complaints;

namespace API.Controllers
{
    [AllowAnonymous]
    public class ComplaintsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ImageService _imageService;

        public ComplaintsController(DataContext context, ImageService imageService)
        {
            _imageService = imageService;
            _context = context;
        }

        [HttpGet] //api/complaints
        public async Task<IActionResult> GetComplaints()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")] //api/complaints/ysgdtvj
        public async Task<IActionResult> GetComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpGet("{complaintType}/{complainantName}/{mobileNum}")] //api/complaints/ysgdtvj
        public async Task<IActionResult> GetComplaintSearchDetails(string complainantName, string mobileNum, string complaintType)
        {
             return HandleResult(await Mediator.Send(new ComplaintsDetails.Query { ComplainantName = complainantName, MobileNum = mobileNum , ComplaintType = complaintType}));
            
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateComplaint(
            [FromForm] CreateComplaintDto createComplaintDto,
            [FromForm] Complaint complaint
        )
        {
            if (createComplaintDto.PictureUrl != null)
            {
                var imageResult = await _imageService.AddImageAsync(createComplaintDto.PictureUrl);

                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                complaint.PhotoUrl = imageResult.SecureUrl.ToString();
                complaint.PublicId = imageResult.PublicId;
            }

            _context.Complaints.Add(complaint);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return BadRequest(new ProblemDetails { Title = "Problem creating new complaint" });
            return Ok();

            // return HandleResult(await Mediator.Send(new Create.Command {Complaint = complaint}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditComplaint(Guid id, [FromForm]Complaint complaint)
        {
            complaint.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Complaint = complaint }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
