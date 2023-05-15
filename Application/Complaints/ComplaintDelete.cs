using Application.Core;
using MediatR;
using Persistence;

namespace Application.Complaints
{
    public class ComplaintDelete
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
                var complaint = await _context.Complaints.FindAsync(request.Id);

                if (complaint == null) return null;

                _context.Remove(complaint);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to delete the complaint");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
