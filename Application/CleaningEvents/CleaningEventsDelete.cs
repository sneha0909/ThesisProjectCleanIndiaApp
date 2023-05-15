using Application.Core;
using MediatR;
using Persistence;

namespace Application.CleaningEvents
{
    public class CleaningEventsDelete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var cleaningEvent = await _context.CleaningEvents.FindAsync(request.Id);

                if (cleaningEvent == null) return null;

                _context.Remove(cleaningEvent);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the cleaning event");

                return Result<Unit>.Success(Unit.Value);

            }
        }
    }
}
