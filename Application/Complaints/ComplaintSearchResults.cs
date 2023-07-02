using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Domain.Enums;

namespace Application.Complaints
{
    public class ComplaintSearchResults
    {
        public class Query : IRequest<Result<Complaint>>
        {
            public string ComplaintDate { get; set; }
            public ComplaintType ComplaintType { get; set; }
            public ComplaintSubType ComplaintSubtype { get; set; }
            public string ComplainantName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Complaint>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Complaint>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var complaints = await _context.Complaints.ToListAsync();

                var complaint = complaints.FirstOrDefault(
                    a =>
                        a.CreatedAt.Date.ToString("yyyy-MM-dd") == request.ComplaintDate
                        && a.ComplaintType == request.ComplaintType
                        && a.ComplaintSubType == request.ComplaintSubtype
                        && a.ComplainantName == request.ComplainantName
                );

                if (complaint == null)
                {
                    return Result<Complaint>.Failure(
                        "No complaint found for the provided details."
                    );
                }

                return Result<Complaint>.Success(complaint);
            }
        }
    }
}
