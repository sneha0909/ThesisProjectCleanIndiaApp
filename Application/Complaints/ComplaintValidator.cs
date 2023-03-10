using Domain;
using FluentValidation;

namespace Application.Complaints
{
    public class ComplaintValidator : AbstractValidator<Complaint>
    {
        public ComplaintValidator()
        {
            RuleFor(x => x.ComplaintType).NotEmpty();
            RuleFor(x => x.ComplaintSubType).NotEmpty();
            RuleFor(x => x.DescriptionofComplaint).NotEmpty();
            RuleFor(x => x.ComplaintLocationHouseNo).NotEmpty();
            RuleFor(x => x.ComplaintLocationHouseName).NotEmpty();
            RuleFor(x => x.ComplaintLocationAreaInAddress).NotEmpty();
            RuleFor(x => x.ComplaintLocationZoneWardNo).NotEmpty();
            RuleFor(x => x.ComplaintLocationArea1).NotEmpty();
            RuleFor(x => x.ComplaintLocationArea2).NotEmpty();
            RuleFor(x => x.ComplaintLocationCity).NotEmpty();
            RuleFor(x => x.ComplaintLocationPincode).NotEmpty();
            RuleFor(x => x.ComplainantName).NotEmpty();
            RuleFor(x => x.ComplainantAddressWard).NotEmpty();
            RuleFor(x => x.ComplainantAddressHouseNo).NotEmpty();
            RuleFor(x => x.ComplainantAddressHouseName).NotEmpty();
            RuleFor(x => x.ComplainantAddressAreaInAddress).NotEmpty();
            RuleFor(x => x.ComplainantAddressZoneWardNo).NotEmpty();
            RuleFor(x => x.ComplainantAddressArea1).NotEmpty();
            RuleFor(x => x.ComplainantAddressArea2).NotEmpty();
            RuleFor(x => x.ComplainantAddressLandmark).NotEmpty();
            RuleFor(x => x.ComplainantAddressCity).NotEmpty();
            RuleFor(x => x.ComplainantAddressState).NotEmpty();
            RuleFor(x => x.ComplainantAddressCountry).NotEmpty();
            RuleFor(x => x.ComplainantAddressSTDCodeOfficeTelephone).NotEmpty();
            RuleFor(x => x.ComplainantAddressOfficeTelephone).NotEmpty();
            RuleFor(x => x.ComplainantAddressSTDCodeResidenceTelephone).NotEmpty();
            RuleFor(x => x.ComplainantAddressResidenceTelephone).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            // RuleFor(x => x.DateOfComplaint).NotEmpty();
            // RuleFor(x => x.ComplaintStatus).NotEmpty();
        
        }
    }
}