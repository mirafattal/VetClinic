using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Pets
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private readonly VetClinicContext _context;
        public AnimalRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public IEnumerable<Animal> GetAnimalbyOwnerID(int ownerId)

        {

            var result = _dbSet.Where(x => x.OwnerId == ownerId).ToList();

            if (result.Count == 0)
            {
                throw new Exception(message: "Error");
            }
            return result;
        }

        public List<Animal> GetAnimalsByAnimalId(int animalId)
        {
            return _context.Animals
                           .Where(a => a.AnimalId == animalId) // Filtering by AnimalId
                           .ToList();
        }

        public IEnumerable<Animal> GetByOwnerId(int ownerId)
        {
            return _dbSet.Where(a => a.OwnerId == ownerId).ToList();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByAnimalTypeId(int animalTypeId)
        {
            return await _context.Animals
                .Where(a => a.AnimalTypeId == animalTypeId)
                .ToListAsync();
        }


        public int CountAnimalsByType(int animalTypeId)
        {
            return _context.Animals
                .Count(animal => animal.AnimalTypeId == animalTypeId);
        }


        public async Task<bool> UpdateAnimalImageAsync(Animal animalToUpdate)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.AnimalId == animalToUpdate.AnimalId);

            if (animal == null)
            {
                return false; // Animal not found
            }

            // Update only the image URL
            animal.ImageUrl = animalToUpdate.ImageUrl;

            _context.Animals.Update(animal); // Track changes
            await _context.SaveChangesAsync(); // Save changes

            return true;
        }


        public async Task<List<Animal>> GetAnimalsByOwnerId(int ownerId)
        {
            var animals = await _context.Animals
                .Where(a => a.OwnerId == ownerId)
                .ToListAsync();

            return animals; // Return the list of animals
        }

        public async Task<IEnumerable<Animal>> GetAnimalsBySearchAsync(string searchTerm, int page, int pageSize)
        {
            var query = _context.Animals.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                // Search by both AnimalName and Breed, case-insensitive
                query = query.Where(i => i.AnimalName.ToLower().Contains(searchTerm.ToLower())
                                          || i.Breed.ToLower().Contains(searchTerm.ToLower()));
            }

            var animals = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return animals;
        }


        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Invoices.CountAsync();
        }

        public async Task<List<Animal>> GetAnimalsAsync(string searchTerm)
        {
            return await _context.Animals
                .Where(a => a.AnimalName.Contains(searchTerm) || a.Breed.Contains(searchTerm) || a.Owner.FullName.Contains(searchTerm))
                .Include(a => a.Owner)  // Ensure you include the Owner entity
                .ToListAsync();
        }
        public async Task<IEnumerable<Animal>> GetAnimalOwnerTable()
        {
            return await _context.Animals
                .Include(a => a.Owner).ToListAsync();

        }
    }
}
