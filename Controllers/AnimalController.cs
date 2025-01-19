using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Pets;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Pets;

namespace VetClinic.Controllers
{
    public class AnimalController : _GenericController<AnimalDto>
    {
        public readonly IAnimalService _animalService;
        private readonly IMapper _mapper;
        public readonly IAnimalRepository _animalRepository;
        public AnimalController(IAnimalService service, IMapper mapper, 
            IAnimalRepository animalRepository) : base(service)
        {
            _animalService = service;
            _mapper = mapper;
            _animalRepository = animalRepository;
        }

        [HttpGet("GetOwnerbyAnimalID")]
        public IEnumerable<GetAnimalbyOwnerIDdto> GetAnimalbyOwnerID(int id)
        {
            return _animalService.GetAnimalbyOwnerID(id);
        }

        [HttpGet("GetAnimalbyId")]
        public ActionResult<List<AnimalDto>> GetAnimalByAnimalId(int animalId)
        {
            try
            {
                var animal = _animalService.GetAnimalByAnimalId(animalId);
                return Ok(animal);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [ProducesResponseType(typeof(IEnumerable<AnimalDto>), 200)]  // Success response with a list of OwnerDto
        [HttpGet("GetbyAnimalTypeId")]
        public async Task<IActionResult> GetAnimalsByAnimalTypeId(int animalTypeId)
        {
            var animals = await _animalService.GetAnimalsByAnimalTypeId(animalTypeId);
            if (animals == null || !animals.Any())
            {
                return NotFound();
            }
            return Ok(animals);
        }

        // In AnimalController.cs
        [HttpGet("counttotalpetpatients")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult CountTotalPetPatients()
        {
            try
            {
                var totalPetPatients = _animalService.CountTotalPetPatients();
                return Ok(totalPetPatients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while counting pet patients.", error = ex.Message });
            }
        }

        // In AnimalController.cs
        [HttpGet("counttotalhorsepatients")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)] // Success response type
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public IActionResult CountTotalHorsePatients()
        {
            try
            {
                var totalHorsePatients = _animalService.CountTotalHorsePatients();
                return Ok(totalHorsePatients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while counting horse patients.", error = ex.Message });
            }
        }


        [HttpPut("updateimage")]
        [ProducesResponseType(typeof(IEnumerable<AnimalImageDto>), 200)]
        public async Task<IActionResult> AddPet([FromForm] AnimalImageDto imageDto, IFormFile? posterFile)
        {
            try
            {
                // Handle Poster Upload
                string? posterUrl = null;
                if (posterFile != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "xrays");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var uniqueFileName = $"{Guid.NewGuid()}_{posterFile.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await posterFile.CopyToAsync(fileStream);
                    }

                    posterUrl = filePath;
                }

                // Map MovieDTO to Movie entity
                var animal = _mapper.Map<Animal>(imageDto);
                animal.ImageUrl = posterUrl;

                // Add the movie to the database
                await _animalRepository.UpdateAnimalImageAsync(animal);

                return Ok(new { message = "Animal updated successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }

        [HttpGet("DownloadImageAnimal")]
        public IActionResult DownloadImage(string imagePath)
        {
            try
            {
                // Base directory where your images are stored
                string baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

                // Full path to the image
                string fullPath = Path.Combine(baseDirectory, imagePath.TrimStart('/'));

                if (!System.IO.File.Exists(fullPath))
                {
                    return NotFound(new { message = "Image not found." });
                }

                // Read the image file
                var fileBytes = System.IO.File.ReadAllBytes(fullPath);
                string contentType = "application/octet-stream";

                // Infer the content type based on file extension
                var extension = Path.GetExtension(fullPath)?.ToLower();
                if (extension == ".jpg" || extension == ".jpeg") contentType = "image/jpeg";
                else if (extension == ".png") contentType = "image/png";
                else if (extension == ".gif") contentType = "image/gif";

                return File(fileBytes, contentType);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing the request.", details = ex.Message });
            }
        }


        [HttpGet("getAllAnimalsByOwnerId")]
        [ProducesResponseType(typeof(List<AnimalDto>), 200)] // Success response with 200 OK
        [ProducesResponseType(404)] // Not Found response
        public async Task<IActionResult> GetAnimalsByOwnerId(int ownerId)
        {
            var animals = await _animalService.GetAnimalsByOwnerId(ownerId);

            if (animals == null || !animals.Any())
            {
                return NotFound("No animals found for the given owner.");
            }

            return Ok(animals);
        }

    }
}
