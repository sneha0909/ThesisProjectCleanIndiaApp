using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Complaints
{
    public class ComplaintsDetails
    {
        public class Query : IRequest<Result<Complaint>>
        {
            public string ComplaintType { get; set; }
            public string ComplainantName { get; set; }
            public string MobileNum { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<Complaint>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

               public async Task<Result<Complaint>> Handle(Query request, CancellationToken cancellationToken)
            {
                var complaint =  await _context.Complaints.Where(a => a.ComplainantName == request.ComplainantName && a.PhoneNumber == request.MobileNum && a.ComplaintType == request.ComplaintType).FirstOrDefaultAsync();

                return Result<Complaint>.Success(complaint);
            }
        }
    }
}
