using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.Vaccinations
{
    public interface IVaccinationRepository: IGenericRepository<Vaccination>
    {
        List<Vaccination> GetVaccinationByAnimalId(int animalId);
        public Task AddVaccinationAsync(Vaccination vaccination);
        public Task<Vaccination> GetVaccinationWithVaccineType(int vaccinationTypeId);
        public Task<int?> GetVaccineTypeIdByVaccinationIdAsync(int vaccinationId);



    }
}
