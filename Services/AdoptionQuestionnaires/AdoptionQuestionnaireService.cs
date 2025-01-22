using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.AdoptionQuestionnaires;
using Vet_DAL.Repositories.Owners;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.AdoptionQuestionnaires
{
    public class AdoptionQuestionnaireService: GenericService<AdoptionQuestionnaire,
        AdoptionQuestionnaireDto>, IAdoptionQuestionnaireService
    {
        public readonly IAdoptionQuestionnaireRepository _adoptionQuestionnaireRepository;
        public readonly IMapper _mapper;
        public readonly IOwnerRepository _ownerRepository;

        public AdoptionQuestionnaireService(IAdoptionQuestionnaireRepository 
            adoptionQuestionnaireRepository, IOwnerRepository ownerRepository,
            IMapper mapper) :
            base(adoptionQuestionnaireRepository, mapper)
        {
            _adoptionQuestionnaireRepository = adoptionQuestionnaireRepository;
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }


        public async Task<AddAdoptionQuestWithOwnerDTO> AddAdoptionQuestionnaireAsync(AddAdoptionQuestWithOwnerDTO dto)
        {
            // Fetch owner by email from the database
            var owner = await _ownerRepository.GetOwnerByEmailAsync(dto.Owner.OwnerEmail);

            if (owner == null)
            {
                // Create a new owner if not found
                owner = _mapper.Map<Owner>(dto.Owner);
                await _ownerRepository.AddOwnerAsync(owner);
                
            }

            // Map DTO to AdoptionQuestionnaire
            var adoptionQuestionnaire = _mapper.Map<AdoptionQuestionnaire>(dto);

            // Link the existing owner with the adoption questionnaire
            adoptionQuestionnaire.UserId = owner.OwnerId; // Set OwnerId correctly here

            // Save the adoption questionnaire
            await _adoptionQuestionnaireRepository.AddAdoptionAsync(adoptionQuestionnaire);

            // Map the saved entity back to the DTO to return
            var resultDto = _mapper.Map<AddAdoptionQuestWithOwnerDTO>(adoptionQuestionnaire);
            resultDto.Owner = _mapper.Map<OwnerDto>(owner); // Ensure the Owner part of the DTO is also populated

            return resultDto;
        }

        public async Task<IEnumerable<AdoptionQuestionnaireDto>> GetAllPendingAsync()
        {
            var pendingQuestionnaires = await _adoptionQuestionnaireRepository.GetAllPendingAsync();
            return _mapper.Map<IEnumerable<AdoptionQuestionnaireDto>>(pendingQuestionnaires);
        }

        public async Task ApproveQuestionnaireAsync(int questionnaireId)
        {
            // Call repository to update the status to "Approved"
            await _adoptionQuestionnaireRepository.UpdateQuestStatusAsync(questionnaireId, "Approved");
        }

        public async Task RejectQuestionnaireAsync(int questionnaireId)
        {
            // Call repository to update the status to "Rejected"
            await _adoptionQuestionnaireRepository.UpdateQuestStatusAsync(questionnaireId, "Rejected");
        }

        public int CountQuestionnairesByPetId(int petId)
        {
            return _adoptionQuestionnaireRepository.CountByPetId(petId);
        }

        public async Task<IEnumerable<GetAllAdoptionQuestwithPetNameDto>> GetAllQuestionnairesByPetIdAsync(int petForAdoptionId)
        {
            // Fetch the questionnaires from the repository
            var questionnaires = await _adoptionQuestionnaireRepository.GetAllQuestionnairesByPetIdAsync(petForAdoptionId);

            // Map to DTO using AutoMapper
            return _mapper.Map<IEnumerable<GetAllAdoptionQuestwithPetNameDto>>(questionnaires);
        }
    }
}

