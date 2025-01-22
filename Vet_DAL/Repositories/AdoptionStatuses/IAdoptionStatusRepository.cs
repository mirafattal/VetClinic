using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.AdoptionStatuses
{
    public interface IAdoptionStatusRepository: IGenericRepository<AdoptionStatus>
    {
    }
}
