using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_BLL.DTOs.OwnerDTOs;

namespace Vet_BLL.Services.Pets
{
    public interface IAnimalService : IGenericService<AnimalDto>
    {
        public IEnumerable<GetAnimalbyOwnerIDdto> GetAnimalbyOwnerID(int id);
        List<AnimalDto> GetAnimalByAnimalId(int animalId);
        public Task<IEnumerable<AnimalDto>> GetAnimalsByAnimalTypeId(int animalTypeId);

        public int CountTotalPetPatients();
        public int CountTotalHorsePatients();

        public Task<List<AnimalDto>> GetAnimalsByOwnerId(int ownerId);

        public Task<PaginationResponseDto<AnimalDto>> SearchAnimalsAsync(string searchTerm, int page, int pageSize);

        public Task<List<AnimalSearchDto>> SearchAnimalsWithOwnersAsync(string searchTerm);
        public Task<IEnumerable<GetAnimalOwnerTable>> GetAnimalOwnerTable();



    }
}
