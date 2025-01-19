using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_BLL.Services.AdoptionQuestionnaires;
using Vet_BLL.Services.Pets;

namespace VetClinic.Controllers
{
    public class AdoptionQuestionnaireController : _GenericController<AdoptionQuestionnaireDto>
    {
        public readonly IAdoptionQuestionnaireService _adoptionQuestionnaireService;
        public AdoptionQuestionnaireController(IAdoptionQuestionnaireService service) : base(service)
        {
            _adoptionQuestionnaireService = service;
        }


        [ProducesResponseType(typeof(AddAdoptionQuestWithOwnerDTO), 200)]
        [ProducesResponseType(typeof(object), 400)] // For BadRequest
        [HttpPost("addAdoptionWithOwner")]
        public async Task<IActionResult> AddOrUpdateAdoptionQuestionnaire([FromBody] AddAdoptionQuestWithOwnerDTO dto)
        {
            try
            {
                var result = await _adoptionQuestionnaireService.AddAdoptionQuestionnaireAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { errorMessage = ex.Message });
            }
        }
        [HttpGet("GetAllPendingStatus")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<AdoptionQuestionnaireDto>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPendingStatus()
        {
            var pendingQuestionnaires = await _adoptionQuestionnaireService.GetAllPendingAsync();
            return Ok(pendingQuestionnaires);
        }

        [HttpPut("ApproveQuest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ApproveQuestionnaire(int id)
        {
            try
            {
                await _adoptionQuestionnaireService.ApproveQuestionnaireAsync(id);
                return Ok("Questionnaire approved successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("RejectQuest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RejectQuestionnaire(int id)
        {
            try
            {
                await _adoptionQuestionnaireService.RejectQuestionnaireAsync(id);
                return Ok("Questionnaire approved successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("countByPetId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]

        public IActionResult GetCountByPetId(int petId)
        {
            try
            {
                int count = _adoptionQuestionnaireService.CountQuestionnairesByPetId(petId);
                return Ok(new PetQuestionnaireCountDto
                {
                    PetId = petId,
                    QuestionnaireCount = count
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred", error = ex.Message });
            }
        }

        [HttpGet("GetByPetID")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAllAdoptionQuestwithPetNameDto>))]

        public async Task<IActionResult> GetAllQuestionnairesByPetId(int petForAdoptionId)
        {
            var questionnaires = await _adoptionQuestionnaireService.GetAllQuestionnairesByPetIdAsync(petForAdoptionId);

            if (questionnaires == null || !questionnaires.Any())
            {
                return NotFound("No questionnaires found for this pet.");
            }

            return Ok(questionnaires);
        }

    }
}
