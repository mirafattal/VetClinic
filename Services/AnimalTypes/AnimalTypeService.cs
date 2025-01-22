using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_BLL.Services.Doctors;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Doctors;
using Vet_DAL.Repositories.Horses;
using Vet_DAL.Repositories.Pets;

namespace Vet_BLL.Services.Horses
{
    public class AnimalTypeService: GenericService<AnimalType, AnimalTypeDto>, IAnimalTypeService
    {
        public readonly IAnimalTypeRepository _animalTypeRepository;
        public readonly IAnimalRepository _animalRepository;
        public readonly IMapper _mapper;

        public AnimalTypeService(IAnimalTypeRepository animalTypeRepository, 
            IAnimalRepository animalRepository,
            IMapper mapper) :
            base(animalTypeRepository, mapper)
        {
            _animalTypeRepository = animalTypeRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }


        //public void AddAnimalTypeWithAnimal(AddAnimalTypeWithAnimalDto animalTypeWithAnimaldto)
        //{
        //    using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
        //    {
        //        try
        //        {
        //            var animalType = _mapper.Map<AnimalType>(animalTypeWithAnimaldto);
        //            _animalTypeRepository.Add(animalType);


        //            foreach (var AnimalTypeDto in animalTypeWithAnimaldto.Animals)
        //            {
        //                var animal = _mapper.Map<Animal>(AnimalTypeDto);
        //                animal.AnimalTypeId = animalType.AnimalTypeId;
        //                _animalRepository.Add(animal);
        //            }


        //            scope.Complete();
        //        }
        //        catch
        //        {

        //            scope.Dispose();
        //            throw;
        //        }
        //    }
        
    }

}

