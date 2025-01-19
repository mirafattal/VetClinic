using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_BLL.Rapping;
using Vet_BLL.Services.PetForAdoptions;
using Vet_BLL.Services.Pets;
using Vet_DAL.Models;
using Vet_DAL.Repositories.PetForAdoptions;

namespace VetClinic.Controllers
{
    public class PetForAdoptionController : _GenericController<PetForAdoptionDto>
    {
        public readonly IPetForAdoptionService _petForAdoptionService;
        private readonly IMapper _mapper;
        private readonly IPetForAdoptionRepository _petforAdoptionRepository;
        public PetForAdoptionController(IPetForAdoptionService service, IMapper mapper, IPetForAdoptionRepository
            petForAdoptionRepository) : base(service)
        {
            _petForAdoptionService = service;
            _mapper = mapper;
            _petforAdoptionRepository = petForAdoptionRepository;
        }

        //[HttpPost("addPetwithimage")]
        //[ProducesResponseType(typeof(IEnumerable<AddPetForAdoptionDto>), 200)]
        //public async Task<IActionResult> AddPetWithImage([FromForm] AddPetForAdoptionDto dto, IFormFile? imageFile)
        //{
        //    if (dto == null)
        //    {
        //        return BadRequest("Pet details are required.");
        //    }

        //    try
        //    {
        //        await _petForAdoptionService.AddPetWithImageAsync(dto, imageFile);
        //        return Ok("Pet added successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        [HttpPost("addPetwithImage")]
        [ProducesResponseType(typeof(IEnumerable<AddPetForAdoptionDto>), 200)]
        public async Task<IActionResult> AddPet([FromForm] AddPetForAdoptionDto petDto, IFormFile? posterFile)
        {


            try
            {
                // Handle Poster Upload
                string? posterUrl = null;
                if (posterFile != null)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "images");
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
                var pet = _mapper.Map<PetForAdoption>(petDto);
                pet.ImageUrl = posterUrl;

                // Add the movie to the database
                await _petforAdoptionRepository.AddPetAsync(pet);

                return Ok(new { message = "Pet added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }


        [HttpGet("DownloadImage")]
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


        [HttpGet("GetAllPetforAdoptionNames")]
        [ProducesResponseType(typeof(IEnumerable<PetForAdoptionDto>), 200)]  // Success response with a list of OwnerDto
        [ProducesResponseType(typeof(string), 400)]  // Bad request with an error message
        [ProducesResponseType(typeof(string), 500)]  // Internal server error with an error message
        public async Task<IActionResult> GetAllPetNames()
        {
            try
            {
                var pets = await _petForAdoptionService.GetAllPetNamesAsync();
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("GetAvailablePets")]
        [ProducesResponseType(typeof(IEnumerable<PetForAdoptionDto>), 200)]  // Success response with a list of OwnerDto

        public async Task<IActionResult> GetAvailablePets()
        {
            var pets = await _petForAdoptionService.GetAvailablePetsAsync();
            return Ok(pets);
        }

        [HttpPut("markPetAsadopted")]
        public async Task<IActionResult> MarkPetAsAdopted(int petId)
        {
            try
            {
                var success = await _petForAdoptionService.MarkPetAsAdoptedAsync(petId);
                if (success)
                {
                    return Ok(new { Message = "Pet marked as adopted successfully." });
                }

                return BadRequest(new { Message = "Failed to mark pet as adopted." });
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
