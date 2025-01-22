using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_BLL.DTOs.AppointmentDTOs;
using Vet_BLL.DTOs.InvoiceDTOs;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.Pets
{
    public class AnimalService: GenericService<Animal, AnimalDto>, IAnimalService
    {
        public readonly IAnimalRepository _animalRepository;
        public readonly IMapper _mapper;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper) :
            base(animalRepository, mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public List<AnimalDto> GetAnimalByAnimalId(int animalId)
        {
            // Get medical records for the given animalId
            var animal = _animalRepository.GetAnimalsByAnimalId(animalId);


            // Map the list of MedicalRecord entities to MedicalRecordDto using AutoMapper
            var animalDto = _mapper.Map<List<AnimalDto>>(animal);

            return animalDto;
        }

        public IEnumerable<GetAnimalbyOwnerIDdto> GetAnimalbyOwnerID(int id)
        {
            var result = _animalRepository.GetAnimalbyOwnerID(id);
            return _mapper.Map<IEnumerable<GetAnimalbyOwnerIDdto>>(result);
        }

        public async Task<IEnumerable<AnimalDto>> GetAnimalsByAnimalTypeId(int animalTypeId)
        {
            var animals = await _animalRepository.GetAnimalsByAnimalTypeId(animalTypeId);
            return _mapper.Map<IEnumerable<AnimalDto>>(animals);
        }

        public int CountTotalPetPatients()
        {
            const int PetAnimalTypeId = 1; // Assuming 1 represents pet patients
            return _animalRepository.CountAnimalsByType(PetAnimalTypeId);
        }

        public int CountTotalHorsePatients()
        {
            const int HorseAnimalTypeId = 2; // Assuming 2 represents horse patients
            return _animalRepository.CountAnimalsByType(HorseAnimalTypeId);
        }

        public async Task<List<AnimalDto>> GetAnimalsByOwnerId(int ownerId)
        {
            // Get the animals from the repository
            var animals = await _animalRepository.GetAnimalsByOwnerId(ownerId);

            // Map the Animal entities to AnimalDto
            var animalDtos = _mapper.Map<List<AnimalDto>>(animals);

            return animalDtos;
        }

        public async Task<PaginationResponseDto<AnimalDto>> SearchAnimalsAsync(string searchTerm, int page, int pageSize)
        {
            var animals = await _animalRepository.GetAnimalsBySearchAsync(searchTerm, page, pageSize);

            var animalDtos = _mapper.Map<List<AnimalDto>>(animals);

            if (animalDtos == null || !animalDtos.Any())
            {
                return new PaginationResponseDto<AnimalDto>
                {
                    Data = new List<AnimalDto>(),
                    TotalRecords = 0
                };
            }
            var totalCount = await _animalRepository.GetTotalCountAsync();

            return new PaginationResponseDto<AnimalDto>
            {
                Data = animalDtos,
                TotalRecords = totalCount
            };
        }

        public async Task<List<AnimalSearchDto>> SearchAnimalsWithOwnersAsync(string searchTerm)
        {
            // Fetch raw data from repository (Animal entities with their Owner)
            var animals = await _animalRepository.GetAnimalsAsync(searchTerm);

            // Use IMapper to map the fetched entities to DTOs
            var animalsWithOwners = _mapper.Map<List<AnimalSearchDto>>(animals);

            return animalsWithOwners;
        }

        public async Task<IEnumerable<GetAnimalOwnerTable>> GetAnimalOwnerTable()
        {
            var animalowner = await _animalRepository.GetAnimalOwnerTable();

            // Assuming you already have your AutoMapper configuration set up
            var animalDto = _mapper.Map<IEnumerable<GetAnimalOwnerTable>>(animalowner);

            // You can also enrich the DTO with additional information if necessary, like animal name, owner name, etc.
            return animalDto;
        }
    }
}
