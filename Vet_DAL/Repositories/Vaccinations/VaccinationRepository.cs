using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Vaccinations
{
    public class VaccinationRepository : GenericRepository<Vaccination>, IVaccinationRepository
    {
        private readonly VetClinicContext _context;
        public VaccinationRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public List<Vaccination> GetVaccinationByAnimalId(int animalId)
        {
            // Retrieve medical records for the given AnimalId
            return _context.Vaccinations
                           .Where(a => a.AnimalId == animalId) // Filtering by AnimalId
                           .ToList();
        }

        public async Task AddVaccinationAsync(Vaccination vaccination)
        {
            await _context.Vaccinations.AddAsync(vaccination);
            await _context.SaveChangesAsync();
        }

        public async Task<Vaccination> GetVaccinationWithVaccineType(int vaccinationTypeId)
        {
            // Fetch Vaccination along with the related VaccineType using the vaccinationTypeId
            return await _context.Vaccinations
                .Include(v => v.VaccineType) // Include the related VaccineType entity
                .FirstOrDefaultAsync(v => v.VaccineTypeId == vaccinationTypeId);
        }

        public async Task<int?> GetVaccineTypeIdByVaccinationIdAsync(int vaccinationId)
        {
            var vaccination = await _context.Vaccinations
                                            .Where(v => v.VaccinationId == vaccinationId)
                                            .FirstOrDefaultAsync();

            return vaccination?.VaccineTypeId;
        }
    }
}
