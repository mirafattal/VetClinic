using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.PetForAdoptions
{
    public interface IPetForAdoptionRepository: IGenericRepository<PetForAdoption>
    {
        public void SaveImagePath(int petId, string imagePath);
        public Task AddPetAsync(PetForAdoption pet);
        public Task<IEnumerable<PetForAdoption>> GetAllPetNamesAsync();
        public Task<IEnumerable<PetForAdoption>> GetAvailablePetsAsync();
        Task<PetForAdoption> GetPetByIdAsync(int petId);
        Task UpdatePetAsync(PetForAdoption pet);
        public void DeletePetForAdoption(int petId);
        Task DeletePetAsync(PetForAdoption petForAdoption);
    }
}
