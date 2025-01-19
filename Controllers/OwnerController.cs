using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_BLL.Rapping;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Owners;

namespace VetClinic.Controllers
{
    public class OwnerController : _GenericController<OwnerDto>
    {

        public readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService service) : base(service)
        {
            _ownerService = service;
        }

        [HttpGet("GetAnimalsByOwnerId")]
        public IActionResult GetAnimalsByOwnerId(int ownerId)
        {
            try
            {
                var result = _ownerService.GetAnimalsByOwnerId(ownerId);
                return Ok(result); // Return 200 OK with the result
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message }); // Return 404 if not found
            }
        }

        [HttpGet("ownerbyanimalID")]
        public ActionResult<OwnerDto> GetOwnerByAnimalId(int animalId)
        {
            try
            {
                var ownerDto = _ownerService.GetOwnerByAnimalId(animalId);
                return Ok(ownerDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        
        }

        [HttpPost("addownerwithanimal")]
        public IActionResult AddOwnerWithAnimal([FromBody] AddOwnerAndAnimalDto ownerAndAnimalDto)
        {
            if (ownerAndAnimalDto == null)
            {
                return BadRequest("Owner and Animal data is null.");
            }

            try
            {
                // Add owner and animal using the service
                _ownerService.AddOwnerWithAnimal(ownerAndAnimalDto);

                return Ok("Owner and Animal added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("deleteownerwithanimal")]
        public IActionResult DeleteOwnerAndAnimal(int ownerId)
        {
            try
            {
                _ownerService.DeleteOwnerAndAnimal(ownerId);
                return Ok("Owner and associated animals deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to delete owner and animals: {ex.Message}");
            }
        }

        [ProducesResponseType(typeof(IEnumerable<OwnerDto>), 200)]  // Success response with a list of OwnerDto
        [ProducesResponseType(typeof(string), 400)]  // Bad request with an error message
        [ProducesResponseType(typeof(string), 500)]  // Internal server error with an error message
        [HttpGet("GetOwnersbyName")]
        public async Task<IActionResult> GetOwnersByName([FromQuery] string? name)
        {
            var owners = await _ownerService.GetOwnersByNameAsync(name);
            return Ok(owners);
        }


        [HttpGet("GetAllOwnerNames")]
        [ProducesResponseType(typeof(IEnumerable<OwnerDto>), 200)]  // Success response with a list of OwnerDto
        [ProducesResponseType(typeof(string), 400)]  // Bad request with an error message
        [ProducesResponseType(typeof(string), 500)]  // Internal server error with an error message
        public async Task<IActionResult> GetAllOwnerNames()
        {
            try
            {
                var owners = await _ownerService.GetAllOwnerNamesAsync();
                return Ok(owners);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("getOwnerIdByUserId")]
        [ProducesResponseType(typeof(int), 200)] // Success: returns OwnerDto with 200 OK
        public async Task<IActionResult> GetOwnerByUserId(int userId)
        {
            var ownerDto = await _ownerService.GetOwnerByUserId(userId);

            if (ownerDto == null)
            {
                return NotFound("Owner not found for the given UserId.");
            }

            return Ok(ownerDto);
        }



    }
}
