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
    public class ComplaintsController : BaseApiController
    {

        [HttpGet] //api/complaints
        public async Task<IActionResult> GetComplaints()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")] //api/complaints/ysgdtvj
        public async Task<IActionResult> GetComplaint(Guid id)
        {

            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }

        [HttpPost]

        public async Task<IActionResult> CreateComplaint(Complaint complaint)
        {
            return HandleResult(await Mediator.Send(new Create.Command {Complaint = complaint}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditComplaint(Guid id, Complaint complaint)
        {
           complaint.Id = id;
           return HandleResult(await Mediator.Send(new Edit.Command{Complaint = complaint}));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteComplaint(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}
 