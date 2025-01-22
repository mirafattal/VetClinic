using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Pets
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
        public IEnumerable<Animal> GetAnimalbyOwnerID(int ownerId);
        List<Animal> GetAnimalsByAnimalId(int animalId);
        public IEnumerable<Animal> GetByOwnerId(int ownerId);
        public Task<IEnumerable<Animal>> GetAnimalsByAnimalTypeId(int animalTypeId);
        public int CountAnimalsByType(int animalTypeId);
        public Task<bool> UpdateAnimalImageAsync(Animal animalToUpdate);
        public Task<List<Animal>> GetAnimalsByOwnerId(int ownerId);
        public Task<IEnumerable<Animal>> GetAnimalsBySearchAsync(string searchTerm, int page, int pageSize);
        public Task<int> GetTotalCountAsync();

        public Task<List<Animal>> GetAnimalsAsync(string searchTerm);
        public Task<IEnumerable<Animal>> GetAnimalOwnerTable();




    }
}

