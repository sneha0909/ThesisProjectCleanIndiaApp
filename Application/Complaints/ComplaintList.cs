using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Complaints
{
    public class ComplaintList
    {
        public class Query : IRequest<Result<PagedList<Complaint>>>
        { 
            public ComplaintParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<Complaint>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<PagedList<Complaint>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var query =  _context.Complaints
                // .Where(status => status.ComplaintStatus == request.Params.ComplaintStatus)
                .AsQueryable();
                return Result<PagedList<Complaint>>.Success(
                    await PagedList<Complaint>.CreateAsync(query, request.Params.PageNumber, 
                    request.Params.PageSize)
                );
                // return Result<PagedList<Complaint>>.Success(await _context.Complaints.ToListAsync());
            }
        }
    }
}
