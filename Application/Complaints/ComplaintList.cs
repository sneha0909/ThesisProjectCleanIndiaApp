using Application.Core;
using Application.Interfaces;
using Domain;
using Domain.Complaints;
using Domain.Complaints.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Complaints
{
    public class ComplaintList
    {
        public class Query : IRequest<Result<List<Complaint>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Complaint>>>
        {
            private readonly DataContext _context;
            private readonly ITranslationAccessor _translationAccessor;

            public Handler(DataContext context, ITranslationAccessor translationAccessor)
            {
                _translationAccessor = translationAccessor;
                _context = context;
            }

            // public async Task<Result<List<TranslatedComplaint>>> Handle(
            //     Query request,
            //     CancellationToken cancellationToken
            // )
            // {
            //     List<string> targetLanguages = new List<string> { "hi", "en" };

            //     List<Complaint> complaints = await _context.Complaints
            //         .Include(c => c.Address)
            //         .ThenInclude(a => a.ComplaintLocation)
            //         .Include(c => c.Address)
            //         .ThenInclude(a => a.ComplainantLocation)
            //         .Include(c => c.TranslatedComplaints)
            //         .ThenInclude(tc => tc.AddressTranslation)
            //         .ToListAsync();

            //     foreach (var complaint in complaints)
            //     {
            //         await _translationAccessor.TranslateComplaintProperties(
            //             complaint,
            //             targetLanguages
            //         );
            //     }

            //     await _context.SaveChangesAsync();

            //     List<TranslatedComplaint> translatedComplaints =
            //         await _context.TranslatedComplaints.ToListAsync();

            //     List<TranslatedComplaint> englishTranslations = translatedComplaints
            //         .Where(tc => tc.Language == ComplaintLanguage.Hindi)
            //         .ToList();

            //     return Result<List<TranslatedComplaint>>.Success(englishTranslations);
            // }

            public async Task<Result<List<Complaint>>> Handle(Query request, CancellationToken cancellationToken)
            {

                var complaints = await _context.Complaints
                    .ToListAsync();

                return Result<List<Complaint>>.Success(complaints);
            }
        }
    }
}
