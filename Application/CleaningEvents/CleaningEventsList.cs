using Application.Core;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.CleaningEvents
{
    public class CleaningEventsList
    {
        public class Query : IRequest<Result<PagedList<CleaningEventDto>>>
        {
            public CleaningEventParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<CleaningEventDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PagedList<CleaningEventDto>>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var query = _context.CleaningEvents
                    .Where(d => d.Date >= request.Params.StartDate)
                    .OrderBy(d => d.Date)
                    .ProjectTo<CleaningEventDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

                if (request.Params.IsGoing && !request.Params.IsHost)
                {
                    query = query.Where(x => x.Attendees.Any(a => a.Username == _userAccessor.GetUsername()));
                }

                if (request.Params.IsHost && !request.Params.IsGoing)
                {
                    query = query.Where(x => x.HostUsername == _userAccessor.GetUsername());
                }

                return Result<PagedList<CleaningEventDto>>.Success(
                    await PagedList<CleaningEventDto>.CreateAsync(query, request.Params.PageNumber,
                         request.Params.PageSize)
                );
            }
        }
    }
}
