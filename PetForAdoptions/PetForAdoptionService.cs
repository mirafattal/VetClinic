using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.AdoptionDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.PetForAdoptions;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.PetForAdoptions
{
    public class PetForAdoptionService: GenericService<PetForAdoption, PetForAdoptionDto>, 
        IPetForAdoptionService
    {
        public readonly IPetForAdoptionRepository _petForAdoptionRepository;
        public readonly IMapper _mapper;

        public PetForAdoptionService(IPetForAdoptionRepository petForAdoptionRepository, 
            IMapper mapper) :
            base(petForAdoptionRepository, mapper)
        {
            _petForAdoptionRepository = petForAdoptionRepository;
            _mapper = mapper;
        }


        public async Task AddPetWithImageAsync(AddPetForAdoptionDto dto)
        {
            var pet = _mapper.Map<PetForAdoption>(dto);

             await _petForAdoptionRepository.AddPetAsync(pet!);
        }

        //public async Task AddPetWithImageAsync(AddPetForAdoptionDto dto, IFormFile imageFile)
        //{
        //    if (imageFile == null || imageFile.Length == 0)
        //    {
        //        throw new ArgumentException("Image file is required.", nameof(imageFile));
        //    }

        //    // Save the image
        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", "Images");
        //    if (!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }

        //    // Generate a unique filename using PetForAdoptionId and the original file extension
        //    var uniqueFileName = $"{dto.PetForAdoptionId}_{Path.GetFileName(imageFile.FileName)}";
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    // Save the file to the server
        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream); // Save image asynchronously
        //    }

        //    // Update DTO with the file path
        //    dto.ImageUrl = Path.Combine("UploadedFiles", "Images", uniqueFileName).Replace("\\", "/"); // Ensure forward slashes for URL

        //    // Map DTO to entity and save to the database
        //    var pet = _mapper.Map<PetForAdoption>(dto);
        //    pet.ImageUrl = dto.ImageUrl;

        //    await _petForAdoptionRepository.AddPetAsync(pet);
        //}



        public async Task<IEnumerable<PetForAdoptionDto>> GetAllPetNamesAsync()
        {
            var pets = await _petForAdoptionRepository.GetAllPetNamesAsync();
            return _mapper.Map<IEnumerable<PetForAdoptionDto>>(pets);
        }

        public async Task<IEnumerable<PetForAdoptionDto>> GetAvailablePetsAsync()
        {
            var pets = await _petForAdoptionRepository.GetAvailablePetsAsync();
            return _mapper.Map<IEnumerable<PetForAdoptionDto>>(pets);
        }

        public async Task<bool> MarkPetAsAdoptedAsync(int petId)
        {
            var petupdate = await _petForAdoptionRepository.GetPetByIdAsync(petId);
            if (petupdate == null)
            {
                throw new ArgumentException("Pet not found");
            }

            // Check if the pet is already adopted
            if (petupdate.AdoptionStatusId == 3)
            {
                throw new InvalidOperationException("Pet is already adopted.");
            }

            petupdate.AdoptionStatusId = 3;
            await _petForAdoptionRepository.UpdatePetAsync(petupdate);
            return true;
        }

        public void DeletePetForAdoption(int petId)
        {
            _petForAdoptionRepository.DeletePetForAdoption(petId);
        }
    }
}
