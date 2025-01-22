using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.DTOs.ZLabDTOs;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.Vaccinations;
using Vet_DAL.Repositories.ZZVaccineTypes;

namespace Vet_BLL.Services.Vaccinations
{
    public class VaccinationService: GenericService<Vaccination, VaccinationDto>, IVaccinationService
    {
        public readonly IVaccinationRepository _vaccinationRepository;
        public readonly IMapper _mapper;
        public readonly IZZVaccineTypeRepository _zzvaccineTypeRepository;

        public VaccinationService(IVaccinationRepository vaccinationRepository, IMapper mapper,
            IZZVaccineTypeRepository zZVaccineTypeRepository) :
            base(vaccinationRepository, mapper)
        {
            _vaccinationRepository = vaccinationRepository;
            _mapper = mapper;
            _zzvaccineTypeRepository = zZVaccineTypeRepository;
        }

        public List<VaccinationDto> GetVaccinationsByAnimalId(int animalId)
        {
            // Get medical records for the given animalId
            var vaccination = _vaccinationRepository.GetVaccinationByAnimalId(animalId);


            // Map the list of MedicalRecord entities to MedicalRecordDto using AutoMapper
            var vaccinationDto = _mapper.Map<List<VaccinationDto>>(vaccination);

            return vaccinationDto;
        }

        public async Task<VaccinationWithVaccineTypeDto> GetVaccinationWithVaccineName(int vaccinationTypeId)
        {
            var vaccination = await _vaccinationRepository.GetVaccinationWithVaccineType(vaccinationTypeId);

            if (vaccination == null)
            {
                return null; // Handle case where vaccination is not found
            }

            // Map the vaccination data along with the vaccineType data into the DTO
            return _mapper.Map<VaccinationWithVaccineTypeDto>(vaccination);
        }

        public async Task<VaccinationDto> GetVaccineTypeIdByVaccinationIdAsync(int vaccinationId)
        {
            var vaccineTypeId = await _vaccinationRepository.GetVaccineTypeIdByVaccinationIdAsync(vaccinationId);

            if (!vaccineTypeId.HasValue)
            {
                // You can handle not found or error here
                return null;
            }

            // Map to DTO
            var dto = new VaccinationDto
            {
                VaccinationId = vaccinationId,
                VaccineTypeId = vaccineTypeId.Value
            };

            return dto;
        }
    }
}
