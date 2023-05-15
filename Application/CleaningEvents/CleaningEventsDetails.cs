using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.CleaningEvents
{
    public class CleaningEventsDetails
    {
        public class Query : IRequest<Result<CleaningEventDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<CleaningEventDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<CleaningEventDto>> Handle(
                Query request,
                CancellationToken cancellationToken
            )
            {
                var cleaningEvent = await _context.CleaningEvents
                    .ProjectTo<CleaningEventDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<CleaningEventDto>.Success(cleaningEvent);
            }
        }
    }
}
