using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Horses
{
    public interface IAnimalTypeRepository: IGenericRepository<AnimalType>
    { 
    }
}
