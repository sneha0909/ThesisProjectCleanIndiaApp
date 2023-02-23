using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Complaints
{
    public class List
    {
        public class Query : IRequest<Result<List<Complaint>>>{ }

        public class Handler : IRequestHandler<Query, Result<List<Complaint>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<Complaint>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                return Result<List<Complaint>>.Success(await _context.Complaints.ToListAsync());
            }
        }
    }
}
