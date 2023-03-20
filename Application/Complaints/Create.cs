using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Complaints
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Complaint Complaint { get; set; }
            // public IFormFile File { get; set; }

            // public CreateComplaintDto createComplaintDto { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Complaint).SetValidator(new ComplaintValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            private readonly IComplaintPhotoAccessor _complaintPhotoAccessor;

            public Handler(
                DataContext context,
                IUserAccessor userAccessor,
                IComplaintPhotoAccessor complaintPhotoAccessor
            )
            {
                _complaintPhotoAccessor = complaintPhotoAccessor;
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {

                var user = await _context.Users.FirstOrDefaultAsync(
                    x => x.ComplainantName == _userAccessor.GetComplainantName()
                );


                 _context.Complaints.Add(request.Complaint);
  

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to create complaint");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
