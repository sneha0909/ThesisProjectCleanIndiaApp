using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc.Routing;
using Persistence;

namespace Application.CleaningEvents
{
    public class CleaningEventsEdit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CleaningEvent CleaningEvent { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CleaningEvent).SetValidator(new CleaningEventValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var cleaningEvent = await _context.CleaningEvents.FindAsync(
                    request.CleaningEvent.Id
                );

                if(cleaningEvent == null) return null;

                _mapper.Map(request.CleaningEvent, cleaningEvent);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update the cleaning event");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
