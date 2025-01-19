using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.Services.Pets;
using Vet_BLL.Services.XrayImages;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Pets;
using Vet_DAL.Repositories.XrayImages;

namespace VetClinic.Controllers
{
    public class XrayImageController : _GenericController<XrayImageDto>
    {
        public readonly IXrayImagesService _xrayImagesService;
        private readonly IMapper _mapper;
        public readonly IXrayImageRepository _xrayImageRepository;
        public XrayImageController(IXrayImagesService service, IMapper mapper, 
            IXrayImageRepository xrayImageRepository) : base(service)
        {
            _xrayImagesService = service;
            _mapper = mapper;
            _xrayImageRepository = xrayImageRepository;
        }

        [HttpPost("addXraywithImage")]
        [ProducesResponseType(typeof(IEnumerable<XrayImageDto>), 200)]
        public async Task<IActionResult> AddXray([FromForm] XrayImageDto xray, IFormFile? posterFile)
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

                // Map Xraydto to Xray entity
                var xrays = _mapper.Map<XrayImage>(xray);
                xrays.ImageUrl = posterUrl;

                // Add the movie to the database
                await _xrayImageRepository.AddXrayAsync(xrays);

                return Ok(new { message = "Xray added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        }


        [HttpGet("DownloadXrayImage")]
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



        [HttpGet("getXRayByAnimalId")]
        [ProducesResponseType(typeof(List<XrayImageDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetXRayByAnimalId(int animalId)
        {
            var xRayImages = await _xrayImagesService.GetXRayByAnimalIdAsync(animalId);

            if (xRayImages == null || !xRayImages.Any())
            {
                return NotFound("No X-ray images found for the given animal ID.");
            }

            return Ok(xRayImages);
        }
    }
}
