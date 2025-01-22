using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.AdoptionDTOs;

namespace Vet_BLL.Services.AdoptionQuestionnaires
{
    public interface IAdoptionQuestionnaireService: IGenericService<AdoptionQuestionnaireDto>
    {
        public Task<AddAdoptionQuestWithOwnerDTO>
        AddAdoptionQuestionnaireAsync(AddAdoptionQuestWithOwnerDTO dto);
        public Task<IEnumerable<AdoptionQuestionnaireDto>> GetAllPendingAsync();
        public Task ApproveQuestionnaireAsync(int questionnaireId);
        public Task RejectQuestionnaireAsync(int questionnaireId);
        public int CountQuestionnairesByPetId(int petId);
        Task<IEnumerable<GetAllAdoptionQuestwithPetNameDto>> GetAllQuestionnairesByPetIdAsync(int petForAdoptionId);




    }
}
