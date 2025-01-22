using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Owners
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly VetClinicContext _context;
        public OwnerRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public Owner GetOwnerWithAnimals(int ownerId)
        {
            return _context.Owners
                .Include(o => o.Animals) // Include related Animals
                .FirstOrDefault(o => o.OwnerId == ownerId);
        }

        public Owner GetOwnerByAnimalId(int animalId)
        {
            // Fetch the owner associated with the given animalId
            var animal = _context.Animals
                                 .Where(a => a.AnimalId == animalId)
                                 .Include(a => a.Owner) // Ensure Owner is loaded with Animal
                                 .FirstOrDefault();

            return animal?.Owner; // Return the associated Owner or null if not found
        }

        public async Task<IEnumerable<Owner>> GetOwnersByNameAsync(string? name)
        {
            return await _context.Owners
                .Where(o => string.IsNullOrEmpty(name) || o.FullName.Contains(name))
                .OrderBy(o => o.FullName)
                .ToListAsync();
        }

        public async Task<IEnumerable<Owner>> GetAllOwnerNamesAsync()
        {
            return await _context.Owners
                .Select(o => new Owner { OwnerId = o.OwnerId, FullName = o.FullName })
                .ToListAsync();
        }

        public async Task<List<string>> GetOwnerEmailsAsync()
        {
            return await _context.Owners.Select(o => o.OwnerEmail).ToListAsync();
        }

        public async Task<Owner> GetOwnerByEmailAsync(string email)
        {
            return await _context.Owners.FirstOrDefaultAsync(o => o.OwnerEmail == email);
        }

        public async Task<Owner> AddOwnerAsync(Owner owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            // Add the owner entity to the database
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();

            return owner;
        }

        public async Task SaveOwnerChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int?> GetOwnerIdByUserId(int userId)
        {
            var owner = await _context.Owners
                .Where(o => o.UserId == userId)
                .FirstOrDefaultAsync();

            return owner?.OwnerId; // Return the ownerId, or null if not found
        }

        public async Task<IEnumerable<Owner>> GetOwnersBySearchAsync(string searchTerm)
        {
            var query = _context.Owners.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
                query = query.Where(x => x.FullName.ToLower().Contains(searchTerm.ToLower()));

            return await query.ToListAsync();
        }

    }
}
