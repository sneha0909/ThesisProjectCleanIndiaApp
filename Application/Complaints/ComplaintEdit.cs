using Application.Core;
using Domain.Enums;
using MediatR;
using Persistence;

namespace Application.Complaints
{
    public class ComplaintEdit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public ComplaintStatus ComplaintStatus { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                var complaint = await _context.Complaints.FindAsync(request.Id);

                if (complaint == null)
                    return Result<Unit>.Failure("Complaint not found");

                complaint.ComplaintStatus = request.ComplaintStatus;
                complaint.UpdatedAt = DateTime.UtcNow;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to update complaint status");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
