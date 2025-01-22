using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;

namespace Vet_BLL.Services.Vaccinations
{
    public interface IVaccinationService: IGenericService<VaccinationDto>
    {
        List<VaccinationDto> GetVaccinationsByAnimalId(int animalId);
        public Task<VaccinationWithVaccineTypeDto> GetVaccinationWithVaccineName(int vaccinationTypeId);
        public Task<VaccinationDto> GetVaccineTypeIdByVaccinationIdAsync(int vaccinationId);


    }
}
