using Microsoft.AspNetCore.Mvc;
using Application.Profiles;

namespace API.Controllers
{
    public class ProfilesController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Edit.Command command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpGet("{username}/cleaningEvents")]
        public async Task<IActionResult> GetUserActivities(string username, string predicate)
        {
            return HandleResult(
                await Mediator.Send(
                    new ListCleaningEvents.Query { Username = username, Predicate = predicate }
                )
            );
        }
    }
}
