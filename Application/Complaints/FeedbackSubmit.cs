using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.FeedbackNamespace
{
    public class FeedbackSubmit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid ComplaintId { get; set; }
            public string Feedback { get; set; }
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
                var complaint = await _context.Complaints.FindAsync(request.ComplaintId);

                if (complaint == null)
                    return Result<Unit>.Failure("Complaint not found");

                var feedback = new Feedback
                {
                    Message = request.Feedback,
                    SubmittedAt = DateTime.UtcNow,
                    ComplaintId = complaint.Id // Set the foreign key property directly
                    
                };

                // complaint.Feedback = feedback; // Associate the feedback with the complaint

                await _context.Feedbacks.AddAsync(feedback);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to submit feedback");


                // Save the changes to the database
                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
