using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Inventories
{
    public class InventoryRepository : GenericRepository<Inventory>, IinventoryRepository
    {
        public InventoryRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
        }
    }
}
