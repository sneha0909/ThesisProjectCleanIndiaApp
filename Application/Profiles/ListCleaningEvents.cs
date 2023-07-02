using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Profiles
{
    public class ListCleaningEvents
    {
        public class Query : IRequest<Result<List<UserCleaningEventDto>>>
        {
            public string Username { get; set; }
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<UserCleaningEventDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<UserCleaningEventDto>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var query = _context.CleaningEventAttendees
                    .Where(u => u.AppUser.UserName == request.Username)
                    .OrderBy(a => a.CleaningEvent.Date)
                    .ProjectTo<UserCleaningEventDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();
                query = request.Predicate switch
                {
                    "past" => query.Where(a => a.Date <= DateTime.Now),
                    "hosting" => query.Where(a => a.HostUsername == request.Username),
                    _ => query.Where(a => a.Date >= DateTime.Now)
                };
                var cleaningEvents = await query.ToListAsync();
                return Result<List<UserCleaningEventDto>>.Success(cleaningEvents);
            }
        }
    }
}
