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
using Application.Core;

namespace API.Controllers
{
    
    public class ComplaintsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ImageService _imageService;


        public ComplaintsController(DataContext context, ImageService imageService)
        {
            _imageService = imageService;
            _context = context;

        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpGet] //api/complaints
        public async Task<IActionResult> GetComplaints([FromQuery]ComplaintParams param)
        {
            return HandlePagedResult(await Mediator.Send(new ComplaintList.Query{Params = param}));
        }

        [HttpGet("{id}")] //api/complaints/ysgdtvj
        public async Task<IActionResult> GetComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new ComplaintDetails.Query { Id = id }));
            
        }

        [HttpGet("{complaintType}/{complainantName}/{mobileNum}")] //api/complaints/ysgdtvj
        public async Task<IActionResult> GetComplaintSearchDetails(string complainantName, string mobileNum, string complaintType)
        {
            
             return HandleResult(await Mediator.Send(new ComplaintSearchResults.Query { ComplainantName = complainantName, MobileNum = mobileNum , ComplaintType = complaintType}));
            
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateComplaint(
            [FromForm] ComplaintDto complaintDto,
            [FromForm] Complaint complaint
        )
        {

            
            if (complaintDto.PictureUrl != null)
            {
                var imageResult = await _imageService.AddImageAsync(complaintDto.PictureUrl);

                if (imageResult.Error != null)
                    return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                complaint.PhotoUrl = imageResult.SecureUrl.ToString();
                complaint.PublicId = imageResult.PublicId;
            }

            // Translate the complaint title and description before adding it to the context

            _context.Complaints.Add(complaint);

            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
                return BadRequest(new ProblemDetails { Title = "Problem creating new complaint" });
            return Ok();

            // return HandleResult(await Mediator.Send(new Create.Command {Complaint = complaint}));
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditComplaint(Guid id, [FromForm]Complaint complaint)
        {
            complaint.Id = id;
            return HandleResult(await Mediator.Send(new ComplaintEdit.Command { Complaint = complaint }));
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new ComplaintDelete.Command { Id = id }));
        }

        
    }
}
