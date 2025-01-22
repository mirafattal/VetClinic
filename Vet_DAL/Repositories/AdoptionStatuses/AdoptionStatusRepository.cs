using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.AdoptionStatuses
{
    public class AdoptionStatusRepository : GenericRepository<AdoptionStatus>, IAdoptionStatusRepository
    {
        private readonly VetClinicContext _context;
        public AdoptionStatusRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }
    }
}
