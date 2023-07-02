using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Complaints
{
    public class ComplaintDetails
    {
        public class Query : IRequest<Result<Complaint>>
        {
            public Guid Id { get; set; }
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
                var complaint =  await _context.Complaints.FindAsync(request.Id);

                return Result<Complaint>.Success(complaint);
            }

               
        }
    }
}
