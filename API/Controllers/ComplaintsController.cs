using API.DTOs;
using API.Services;
using Persistence;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Complaints;
using Domain.Enums;
using Application.FeedbackNamespace;
using Domain.Complaints;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace API.Controllers
{
    public class ComplaintsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ImageService _imageService;

        public ComplaintsController(DataContext context, ImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpGet] //api/complaints
        public async Task<IActionResult> GetComplaints()
        {
            return HandleResult(await Mediator.Send(new ComplaintList.Query()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")] //api/complaints/ysgdtvj
        public async Task<IActionResult> GetComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new ComplaintDetails.Query { Id = id }));
        }

        [AllowAnonymous]
        [HttpGet("{complaintDate}/{complaintType}/{complaintSubtype}/{complainantName}")]
        public async Task<IActionResult> GetComplaintSearchDetails(
            string complaintDate,
            ComplaintType complaintType,
            ComplaintSubType complaintSubtype,
            string complainantName
        )
        {
            return HandleResult(
                await Mediator.Send(
                    new ComplaintSearchResults.Query
                    {
                        ComplaintDate = complaintDate,
                        ComplaintType = complaintType,
                        ComplaintSubtype = complaintSubtype,
                        ComplainantName = complainantName
                    }
                )
            );
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateComplaint([FromForm] ComplaintDto complaintDto)
        {
            try
            {
                var complaint = new Complaint
                {
                    Id = Guid.NewGuid(),
                    ComplaintType = complaintDto.ComplaintType,
                    ComplaintSubType = complaintDto.ComplaintSubType,
                    Description = complaintDto.Description,
                    ComplainantName = complaintDto.ComplainantName,
                    PhoneNumber = complaintDto.PhoneNumber,
                    Email = complaintDto.Email,
                    ComplaintStatus = ComplaintStatus.Filed,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = null,
                    Feedback = new Feedback { Id = Guid.NewGuid() } // Create a placeholder Feedback entity
                };

                // Create the address
                var address = new Address
                {
                    Id = Guid.NewGuid(),
                    Pincode = complaintDto.Pincode,
                    StateId = complaintDto.selectedState,
                    CityId = complaintDto.selectedCity
                };

                // Create the complaint location
                var complaintLocation = new ComplaintLocation
                {
                    ComplaintLocationWardNo = complaintDto.ComplaintLocationWardNo,
                    ComplaintLocationArea = complaintDto.ComplaintLocationArea,
                    ComplaintLocationLandmark = complaintDto.ComplaintLocationLandmark,
                    Address = address // Set the address for the complaint location
                };

                // Create the complainant location
                var complainantLocation = new ComplainantLocation
                {
                    ComplainantLocationWardNo = complaintDto.ComplainantLocationWardNo,
                    ComplainantLocationHouseNo = complaintDto.ComplainantLocationHouseNo,
                    ComplainantLocationHouseName = complaintDto.ComplainantLocationHouseName,
                    ComplainantLocationLandmark = complaintDto.ComplainantLocationLandmark,
                    ComplainantLocationArea = complaintDto.ComplainantLocationArea,
                    Address = address // Set the address for the complainant location
                };

                // Assign the complaint location and complainant location objects to the address properties (composition relationship)
                address.ComplaintLocation = complaintLocation;
                address.ComplainantLocation = complainantLocation;

                // Set the address for the complaint
                complaint.Address = address;
                if (complaintDto.PictureUrl != null)
                {
                    var imageResult = await _imageService.AddImageAsync(complaintDto.PictureUrl);

                    if (imageResult.Error != null)
                        return BadRequest(new ProblemDetails { Title = imageResult.Error.Message });

                    complaint.PhotoUrl = imageResult.SecureUrl.ToString();
                    complaint.PublicId = imageResult.PublicId;
                }

                _context.Complaints.Add(complaint);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return BadRequest(
                        new ProblemDetails { Title = "Problem creating new complaint" }
                    );

                return Ok();
            }
            catch (DbUpdateException ex)
            {
                Exception innerException = ex.InnerException;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                string errorMessage = innerException.Message;
                string stackTrace = innerException.StackTrace;
                return BadRequest(
                    new ProblemDetails
                    {
                        Title = "An error occurred while saving the entity changes"
                    }
                );
            }
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditComplaint(Guid id, [FromForm] int complaintStatus)
        {
            if (!Enum.IsDefined(typeof(ComplaintStatus), complaintStatus))
            {
                return BadRequest("Invalid complaint status");
            }

            return HandleResult(
                await Mediator.Send(
                    new ComplaintEdit.Command
                    {
                        Id = id,
                        ComplaintStatus = (ComplaintStatus)complaintStatus
                    }
                )
            );
        }

        //[Authorize(Roles = "Admin")]
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new ComplaintDelete.Command { Id = id }));
        }

        [AllowAnonymous]
        //[Authorize(Roles = "Admin")]
        [HttpPost("{id}/feedback")]
        public async Task<IActionResult> SubmitFeedback(Guid id, string feedback)
        {
            return HandleResult(
                await Mediator.Send(
                    new FeedbackSubmit.Command { ComplaintId = id, Feedback = feedback }
                )
            );
        }

        [AllowAnonymous]
        [HttpGet("/api/Address/{addressId}")]
        public async Task<IActionResult> GetAddress(Guid addressId)
        {
            var address = await _context.Addresses.FindAsync(addressId);
            if (address == null)
            {
                return NotFound();
            }

            var state = await _context.States.FindAsync(address.StateId);
            if (state == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FindAsync(address.CityId);
            if (city == null)
            {
                return NotFound();
            }

            var addressData = new { State = state, City = city };

            return Ok(addressData);
        }
    }
}
