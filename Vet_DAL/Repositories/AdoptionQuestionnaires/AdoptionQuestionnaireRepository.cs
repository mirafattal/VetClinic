using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.AdoptionQuestionnaires
{
    public class AdoptionQuestionnaireRepository : GenericRepository<AdoptionQuestionnaire>,
        IAdoptionQuestionnaireRepository
    {

        private readonly VetClinicContext _context;
        public AdoptionQuestionnaireRepository(VetClinicContext vetClinicContext) :
            base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public async Task<AdoptionQuestionnaire> AddAdoptionAsync(AdoptionQuestionnaire adoptionQuestionnaire)
        {
            if (adoptionQuestionnaire == null)
                throw new ArgumentNullException(nameof(adoptionQuestionnaire));

            // Add the adoption questionnaire entity to the database
            await _context.AdoptionQuestionnaires.AddAsync(adoptionQuestionnaire);
            await _context.SaveChangesAsync();

            return adoptionQuestionnaire;
        }

        public async Task<IEnumerable<AdoptionQuestionnaire>> GetAllPendingAsync()
        {
            return await _context.AdoptionQuestionnaires
                .Where(q => q.QuestionStatus == "Pending" || q.QuestionStatus == "Approved")
                .ToListAsync();
        }

        public async Task UpdateQuestStatusAsync(int questionnaireId, string status)
        {
            var questionnaire = await _context.AdoptionQuestionnaires.FindAsync(questionnaireId);
            if (questionnaire == null)
            {
                throw new KeyNotFoundException("Questionnaire not found.");
            }

            questionnaire.QuestionStatus = status;
            _context.AdoptionQuestionnaires.Update(questionnaire);
            await _context.SaveChangesAsync();
        }

        public int CountByPetId(int petId)
        {
            return _context.AdoptionQuestionnaires
                           .Count(q => q.PetForAdoptionId == petId && q.QuestionStatus == "Pending");
        }

        public async Task<IEnumerable<AdoptionQuestionnaire>> GetAllQuestionnairesByPetIdAsync(int petForAdoptionId)
        {
            return await _context.AdoptionQuestionnaires
                .Where(q => q.PetForAdoptionId == petForAdoptionId &&
                            (q.QuestionStatus == "Approved" || q.QuestionStatus == "Pending"))
                .ToListAsync();
        }
    }
    
}
