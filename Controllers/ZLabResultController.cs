using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.ZLabDTOs;
using Vet_BLL.Services.Pets;
using Vet_BLL.Services.ZLabResults;
using Vet_DAL.Repositories.Pets;

namespace VetClinic.Controllers
{
    public class ZLabResultController : _GenericController<ZLabResultDto>
    {
        public readonly IZLabResultService _zLabResultService;
        
        public ZLabResultController(IZLabResultService service) : base(service)
        {
            _zLabResultService = service;
           
        }

        [HttpGet("GetLabbyanimalId")]
        public ActionResult<List<ZLabResultDto>> GetVaccinationsByAnimalId(int animalId)
        {
            try
            {
                var lab = _zLabResultService.GetResultsByAnimalId(animalId);
                return Ok(lab);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddLabResult")]
        [ProducesResponseType(typeof(ZLabResultResponseDto), StatusCodes.Status200OK)] // Success response
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)] // Key not found
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)] // Internal server error
        public async Task<IActionResult> AddLabResult([FromBody] ZLabResultDto labResultDto)
        {
            try
            {
                var result = await _zLabResultService.AddLabResultAsync(labResultDto);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", details = ex.Message });
            }
        }

    }
}
