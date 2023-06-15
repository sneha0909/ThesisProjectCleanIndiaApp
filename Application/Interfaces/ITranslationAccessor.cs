using Domain;
using Domain.Complaints;

namespace Application.Interfaces
{
    public interface ITranslationAccessor
    {
        Task<TranslatedComplaint> TranslateComplaintProperties(Complaint complaint, List<string> targetLanguages);
        
    }
    
}