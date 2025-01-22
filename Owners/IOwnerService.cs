using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.OwnerDTOs;

namespace Vet_BLL.Services.Owners
{
    public interface IOwnerService : IGenericService<OwnerDto>
    {
        public GetAnimalbyOwnerIDdto GetAnimalsByOwnerId(int ownerId);
        public OwnerDto GetOwnerByAnimalId(int animalId);
        public void AddOwnerWithAnimal(AddOwnerAndAnimalDto owneranimalDto);
        public void DeleteOwnerAndAnimal(int ownerId);
        public Task<IEnumerable<OwnerDto>> GetOwnersByNameAsync(string? name);
        public Task<IEnumerable<OwnerDto>> GetAllOwnerNamesAsync();
        public Task<int> GetOwnerByUserId(int userId);
        public Task<List<OwnerDto>> GetOwnersBySearchAsync(string pattern);


    }
}
