using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.PetForAdoptions
{
    public class PetForAdoptionRepository: GenericRepository<PetForAdoption>, IPetForAdoptionRepository
    {
        private readonly VetClinicContext _context;

        public PetForAdoptionRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public void SaveImagePath(int petId, string imagePath)
        {
            var petadoption = _context.PetForAdoptions.Find(petId); // Synchronous Find
            if (petadoption != null)
            {
                petadoption.ImageUrl = imagePath;
                _context.SaveChanges(); // Synchronous SaveChanges
            }
        }

        public async Task AddPetAsync(PetForAdoption pet)
        {
            await _context.PetForAdoptions.AddAsync(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PetForAdoption>> GetAllPetNamesAsync()
        {
            return await _context.PetForAdoptions
                .Select(o => new PetForAdoption { PetForAdoptionId = o.PetForAdoptionId, 
                    PetName = o.PetName })
                .ToListAsync();
        }

        public async Task<IEnumerable<PetForAdoption>> GetAvailablePetsAsync()
        {
            return await _context.PetForAdoptions
                .Where(pet => !_context.AdoptionQuestionnaires
                    .Any(aq => aq.PetForAdoptionId == pet.PetForAdoptionId && aq.QuestionStatus == "approved"))
                .ToListAsync();
        }

        public async Task<PetForAdoption> GetPetByIdAsync(int petId)
        {
            return await _context.PetForAdoptions.FirstOrDefaultAsync(p => p.PetForAdoptionId == petId);
        }

        public async Task UpdatePetAsync(PetForAdoption pet)
        {
            _context.PetForAdoptions.Update(pet);
            await _context.SaveChangesAsync();
        }

        public void DeletePetForAdoption(int petId)
        {
            // Fetch the pet and include its associated adoption questionnaires
            var pet = _context.PetForAdoptions
                .Include(p => p.AdoptionQuestionnaires) // Correct navigation property name
                .FirstOrDefault(p => p.PetForAdoptionId == petId);

            if (pet == null)
            {
                throw new Exception($"Pet with ID {petId} not found.");
            }

            // Remove associated adoption questionnaires
            if (pet.AdoptionQuestionnaires != null && pet.AdoptionQuestionnaires.Any())
            {
                _context.AdoptionQuestionnaires.RemoveRange(pet.AdoptionQuestionnaires);
            }

            // Remove the pet
            _context.PetForAdoptions.Remove(pet);
            _context.SaveChanges();
        }



        public async Task DeletePetAsync(PetForAdoption petForAdoption)
        {
            _context.PetForAdoptions.Remove(petForAdoption);
            await _context.SaveChangesAsync();
        }
    }
}
