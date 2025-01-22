using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.AnimalDTOs;

namespace Vet_BLL.Services.Horses
{
    public interface IAnimalTypeService : IGenericService<AnimalTypeDto>
    {
        //void AddAnimalTypeWithAnimal(AddAnimalTypeWithAnimalDto animalTypeWithAnimaldto);
    }
}
