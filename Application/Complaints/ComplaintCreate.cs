using Application.Core;
using Application.Interfaces;
using Domain;
using Domain.Enums;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;

namespace Application.Complaints
{
    public class ComplaintCreate
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Complaint Complaint { get; set; }
            public IFormFile File { get; set; }

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

            private readonly IPhotoAccessor _photoAccessor;

            public Handler(
                DataContext context,
                IUserAccessor userAccessor,
                IPhotoAccessor photoAccessor
                
            )
            {
                _userAccessor = userAccessor;
                _photoAccessor = photoAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(
                Command request,
                CancellationToken cancellationToken
            )
            {
                request.Complaint.ComplaintStatus = ComplaintStatus.Filed;
                request.Complaint.CreatedAt = DateTime.UtcNow;

                if (request.File != null)
                {
                    var photoUploadResult = await _photoAccessor.AddPhoto(request.File);

                    request.Complaint.PhotoUrl = photoUploadResult.Url;
                    request.Complaint.PublicId = photoUploadResult.PublicId;
                }

                _context.Complaints.Add(request.Complaint);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to create complaint");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
