using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.CleaningEvents
{
    public class CleaningEventsCreate
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CleaningEvent CleaningEvent { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CleaningEvent).SetValidator(new CleaningEventValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var attendee = new CleaningEventAttendee
                {
                    AppUser = user,
                    CleaningEvent = request.CleaningEvent,
                    IsHost = true
                };

                request.CleaningEvent.Attendees.Add(attendee);
                
                _context.CleaningEvents.Add(request.CleaningEvent);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to create cleaning event");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
