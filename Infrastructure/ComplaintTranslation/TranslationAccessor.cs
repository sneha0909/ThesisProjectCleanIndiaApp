using Application.Interfaces;
using Domain;
using Domain.Complaints;
using Domain.Complaints.Enums;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.ComplaintTranslation
{
    public class TranslationAccessor : ITranslationAccessor
    {
        private readonly AmazonTranslateService _translateService;
        private readonly DataContext _context;

        public TranslationAccessor(AmazonTranslateService translateService, DataContext context)
        {
            _context = context;
            _translateService = translateService;
        }

        public async Task<TranslatedComplaint> TranslateComplaintProperties(
            Complaint complaint,
            List<string> targetLanguages
        )
        {
            TranslatedComplaint translatedComplaint = new TranslatedComplaint
            {
                ComplaintId = complaint.Id
            };

            foreach (var targetLanguage in targetLanguages)
            {
                TranslatedComplaint existingTranslation =
                    await _context.TranslatedComplaints.FirstOrDefaultAsync(
                        tc => tc.ComplaintId == complaint.Id
                    );

                if (existingTranslation != null)
                {
                    translatedComplaint = existingTranslation;
                }
                else
                {
                    translatedComplaint = new TranslatedComplaint
                    {
                        TranslatedDescription = await TranslateProperty(
                            complaint.Description,
                            targetLanguage
                        ),
                        TranslatedComplainantName = await TranslateProperty(
                            complaint.ComplainantName,
                            targetLanguage
                        ),
                        ComplaintId = complaint.Id,
                        Language = GetComplaintLanguage(targetLanguage)
                    };

                    translatedComplaint.AddressTranslation = await TranslateAddress(
                        complaint.Address,
                        targetLanguage
                    );

                    complaint.TranslatedComplaints.Add(translatedComplaint);
                }
            }
            await _context.SaveChangesAsync();

            return translatedComplaint;
        }

        private async Task<AddressTranslation> TranslateAddress(
            Address address,
            string targetLanguage
        )
        {
            AddressTranslation translatedAddress = new AddressTranslation();

            if (address.ComplaintLocation != null)
            {
                translatedAddress.TranslatedComplaintLocationArea = await TranslateProperty(
                    address.ComplaintLocation.ComplaintLocationArea,
                    targetLanguage
                );
                translatedAddress.TranslatedComplaintLocationLandmark = await TranslateProperty(
                    address.ComplaintLocation.ComplaintLocationLandmark,
                    targetLanguage
                );
            }

            if (address.ComplainantLocation != null)
            {
                translatedAddress.TranslatedComplainantLocationArea = await TranslateProperty(
                    address.ComplainantLocation.ComplainantLocationArea,
                    targetLanguage
                );
                translatedAddress.TranslatedComplainantLocationHouseName = await TranslateProperty(
                    address.ComplainantLocation.ComplainantLocationHouseName,
                    targetLanguage
                );
                translatedAddress.TranslatedComplainantLocationLandmark = await TranslateProperty(
                    address.ComplainantLocation.ComplainantLocationLandmark,
                    targetLanguage
                );
            }

            translatedAddress.Language = GetComplaintLanguage(targetLanguage);

            return translatedAddress;
        }

        private async Task<string> TranslateProperty(string text, string targetLanguage)
        {
            // Call the AmazonTranslateService to detect the language of the text
            string detectedLanguageCode = await _translateService.DetectLanguage(text);
            ComplaintLanguage detectedLanguage = GetComplaintLanguage(detectedLanguageCode);

            if (
                detectedLanguage != ComplaintLanguage.Hindi
                && detectedLanguage != ComplaintLanguage.English
            )
            {
                // Call the AmazonTranslateService to translate the text
                string translatedText = await _translateService.TranslateText(text, targetLanguage);
                return translatedText;
            }
            else
            {
                return text;
            }
        }

        private ComplaintLanguage GetComplaintLanguage(string targetLanguage)
        {
            Dictionary<string, ComplaintLanguage> languageMap = new Dictionary<
                string,
                ComplaintLanguage
            >
            {
                { "hi", ComplaintLanguage.Hindi },
                { "en", ComplaintLanguage.English },
            };
            if (languageMap.TryGetValue(targetLanguage, out var enumValue))
            {
                return enumValue;
            }
            else
            {
                // Handle the case when the target language is not supported
                throw new ArgumentException("Unsupported target language");
            }
        }
    }
}