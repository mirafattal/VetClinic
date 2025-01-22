using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Pets;

namespace Vet_DAL.Repositories.StaffRoles
{
    public class StaffRoleRepository: GenericRepository<StaffRole>, IStaffRoleRepository
    {
        private readonly VetClinicContext _context;
        public StaffRoleRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }
    }
}
