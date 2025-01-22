using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Owners
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        public Owner GetOwnerWithAnimals(int ownerId);
        public Owner GetOwnerByAnimalId(int animalId);
        public Task<IEnumerable<Owner>> GetOwnersByNameAsync(string? name);
        public Task<IEnumerable<Owner>> GetAllOwnerNamesAsync();
        public Task<List<string>> GetOwnerEmailsAsync();
        public Task<Owner> GetOwnerByEmailAsync(string email);
        public Task<Owner> AddOwnerAsync(Owner owner);
        public Task SaveOwnerChangesAsync();
        public Task<int?> GetOwnerIdByUserId(int userId);
        public Task<IEnumerable<Owner>> GetOwnersBySearchAsync(string searchTerm);


    }
}
