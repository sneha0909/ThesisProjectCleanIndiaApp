using Domain;
using FluentValidation;

namespace Application.Complaints
{
    public class ComplaintValidator : AbstractValidator<Complaint>
    {
        public ComplaintValidator()
        {
            RuleFor(x => x.ComplainantName).NotEmpty();
            RuleFor(x => x.DateOfComplaint).NotEmpty();
            RuleFor(x => x.State).NotEmpty();
            RuleFor(x => x.District).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.MunicipalCorporation).NotEmpty();
        }
    }
}