using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.ZZVaccineTypes
{
    public class ZZVaccineTypeRepository: GenericRepository<ZzvaccineType>, IZZVaccineTypeRepository
    {
        private readonly VetClinicContext _context;
        public ZZVaccineTypeRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public async Task<List<ZzvaccineType>> GetVaccinationTemplatesAsync()
        {
            return await _context.ZzvaccineTypes.ToListAsync();
        }
    }
}
