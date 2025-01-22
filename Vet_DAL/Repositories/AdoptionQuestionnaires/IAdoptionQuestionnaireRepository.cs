using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.AdoptionQuestionnaires
{
    public interface IAdoptionQuestionnaireRepository: IGenericRepository<AdoptionQuestionnaire>
    {
        public Task<AdoptionQuestionnaire> AddAdoptionAsync(AdoptionQuestionnaire adoptionQuestionnaire);
        public Task<IEnumerable<AdoptionQuestionnaire>> GetAllPendingAsync();
        public Task UpdateQuestStatusAsync(int questionnaireId, string status);
        public int CountByPetId(int petId);
        Task<IEnumerable<AdoptionQuestionnaire>> GetAllQuestionnairesByPetIdAsync(int petForAdoptionId);



    }
}
