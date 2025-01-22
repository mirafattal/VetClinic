using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Owners;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.Owners
{
    public class OwnerService : GenericService<Owner, OwnerDto>, IOwnerService
    {
        public readonly IOwnerRepository _ownerRepository;
        public readonly IAnimalRepository _animalRepository;
        public readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IAnimalRepository animalRepository,
            IMapper mapper) :
            base(ownerRepository, mapper)
        {
            _ownerRepository = ownerRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public GetAnimalbyOwnerIDdto GetAnimalsByOwnerId(int ownerId)
        {
            var owner = _ownerRepository.GetOwnerWithAnimals(ownerId);
            return _mapper.Map<GetAnimalbyOwnerIDdto>(owner);
        }

        public OwnerDto GetOwnerByAnimalId(int animalId)
        {
            // Get the owner associated with the animalId
            var owner = _ownerRepository.GetOwnerByAnimalId(animalId);

            // Map the Owner entity to OwnerByAnimalIdDto using AutoMapper
            var ownerDto = _mapper.Map<OwnerDto>(owner);

            return ownerDto;
        }

        public void AddOwnerWithAnimal(AddOwnerAndAnimalDto owneranimalDto)
        {
            // Map OwnerDto to Owner, which includes the Animal
            var owner = _mapper.Map<Owner>(owneranimalDto);

            // Add the owner (and the associated animals) to the repository
            _ownerRepository.Add(owner);
        }

        public void DeleteOwnerAndAnimal(int ownerId)
        {
            // First, get the owner and make sure they exist
            var owner = _ownerRepository.GetById(ownerId);
            if (owner == null)
            {
                throw new Exception("Owner not found");
            }

            // Get and delete all animals associated with the owner
            var animals = _animalRepository.GetByOwnerId(ownerId);
            foreach (var animal in animals)
            {
                _animalRepository.Delete(animal);
            }

            // Now delete the owner
            _ownerRepository.Delete(owner);
        }

        public async Task<IEnumerable<OwnerDto>> GetOwnersByNameAsync(string? name)
        {
            // Fetch owners from repository
            var owners = await _ownerRepository.GetOwnersByNameAsync(name);

            return _mapper.Map<IEnumerable<OwnerDto>>(owners);
        }

        public async Task<IEnumerable<OwnerDto>> GetAllOwnerNamesAsync()
        {
            var owners = await _ownerRepository.GetAllOwnerNamesAsync();
            return _mapper.Map<IEnumerable<OwnerDto>>(owners);
        }

        public async Task<int> GetOwnerByUserId(int userId)
        {
            var ownerId = await _ownerRepository.GetOwnerIdByUserId(userId);

            // If ownerId is null, return a default value (e.g., 0) indicating no owner was found
            if (!ownerId.HasValue)
            {
                return 0; // Default value indicating no owner found
            }

            return ownerId.Value; // Return the ownerId as an int
        }

        public async Task<List<OwnerDto>> GetOwnersBySearchAsync(string pattern)
        {
            var movies = await _ownerRepository.GetOwnersBySearchAsync(pattern);

            if (movies == null || !movies.Any())
                return new List<OwnerDto>(); 

            return _mapper.Map<List<OwnerDto>>(movies); 
        }

    }
}

