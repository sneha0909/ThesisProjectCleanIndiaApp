using Application.CleaningEvents;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    public class CleaningEventsController : BaseApiController
    {

        
        [HttpGet] //api/cleaningEvents
        public async Task<IActionResult> GetCleaningEvents([FromQuery]CleaningEventParams param)
        {
            return HandlePagedResult(await Mediator.Send(new CleaningEventsList.Query{Params = param}));
        }

        
        [HttpGet("{id}")] //api/cleaningEvents/id
        public async Task<IActionResult> GetCleaningEvent(Guid id)
        {
            return HandleResult(await Mediator.Send(new CleaningEventsDetails.Query{Id = id}));
        }

        
        [HttpPost]

        public async Task<IActionResult> CreateCleaningEvent(CleaningEvent cleaningEvent)
        {
            return HandleResult(await Mediator.Send(new CleaningEventsCreate.Command {CleaningEvent = cleaningEvent}));
        }


        
        [Authorize(Policy = "IsCleaningEventHost")]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditCleaningEvent(Guid id, CleaningEvent cleaningEvent)
        {
            cleaningEvent.Id = id;
            return HandleResult(await Mediator.Send(new CleaningEventsEdit.Command{CleaningEvent = cleaningEvent}));
        }


        
        [Authorize(Policy = "IsCleaningEventHost")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCleaningEvent(Guid id)
        {
            return HandleResult(await Mediator.Send(new CleaningEventsDelete.Command{Id = id}));
        }

        
        [HttpPost("{id}/attend")]
        public async Task<IActionResult> Attend(Guid id)
        {
            return HandleResult(await Mediator.Send(new UpdateAttendance.Command{Id = id}));
        }
    }
}
