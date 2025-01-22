using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.AdoptionDTOs;

namespace Vet_BLL.Services.PetForAdoptions
{
    public interface IPetForAdoptionService: IGenericService<PetForAdoptionDto>
    {

        public Task AddPetWithImageAsync(AddPetForAdoptionDto dto);
        public Task<IEnumerable<PetForAdoptionDto>> GetAllPetNamesAsync();
        public Task<IEnumerable<PetForAdoptionDto>> GetAvailablePetsAsync();
        Task<bool> MarkPetAsAdoptedAsync(int petId);
        public void DeletePetForAdoption(int petId);


    }
}
