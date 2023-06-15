using Domain;
using FluentValidation;

namespace Application.Complaints
{
    public class ComplaintValidator : AbstractValidator<Complaint>
    {
        public ComplaintValidator()
        {

            // RuleFor(x => x.ComplaintType)
            //     .NotEmpty();

            // RuleFor(x => x.ComplaintSubType)
            //     .NotEmpty();

            // RuleFor(x => x.Description)
            //     .NotEmpty();
                
            // RuleFor(x => x.ComplaintLocationArea)
            //     .NotEmpty();

            // RuleFor(x => x.ComplaintLocationPincode)
            //     .NotEmpty();
            
            // RuleFor(x => x.ComplaintLocationWardNo)
            //     .NotEmpty();

            // RuleFor(x => x.ComplainantName)
            //     .NotEmpty();

            // RuleFor(x => x.ComplainantWardNo)
            //     .NotEmpty();

            // RuleFor(x => x.ComplainantHouseNo)
            //     .NotEmpty();

            // RuleFor(x => x.ComplainantArea)
            //     .NotEmpty();

            // RuleFor(x => x.ComplainantLandmark)
            //     .NotEmpty();


            // RuleFor(x => x.PhoneNumber)
            //     .NotEmpty();

            // RuleFor(x => x.Email)
            //     .NotEmpty();

        
        }
    }
}