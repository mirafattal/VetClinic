using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.MedicalRecords;

namespace Vet_BLL.Services.MedicalRecords
{
    public class MedicalRecordService: GenericService<MedicalRecord, MedicalRecordDto>, IMedicalRecordService
    {
        public readonly IMedicalRecordRepository _medicalRecordRepository;
        public readonly IMapper _mapper;

        public MedicalRecordService(IMedicalRecordRepository medicalRecordRepository, IMapper mapper) :
            base(medicalRecordRepository, mapper)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _mapper = mapper;
        }

        public List<MedicalRecordDto> GetMedicalRecordsByAnimalId(int animalId)
        {
            // Get medical records for the given animalId
            var medicalRecords = _medicalRecordRepository.GetMedicalRecordsByAnimalId(animalId);


            // Map the list of MedicalRecord entities to MedicalRecordDto using AutoMapper
            var medicalRecordsDto = _mapper.Map<List<MedicalRecordDto>>(medicalRecords);

            return medicalRecordsDto;
        }

        public async Task<MedicalRecord> UpdateMedicalRecordAsync(MedicalRecordDto updateDto)
        {
            // Get the existing medical record
            var medicalRecord = await _medicalRecordRepository.GetByIdAsync(updateDto.MedicalRecordId);
            if (medicalRecord == null)
            {
                throw new Exception("Medical record not found");
            }

            updateDto.AnimalId = medicalRecord.AnimalId;
            updateDto.MedicalRecordId = medicalRecord.MedicalRecordId;
            updateDto.StaffId = medicalRecord.StaffId;
            // Map the DTO to the entity
            _mapper.Map(updateDto, medicalRecord);

            // Update the record in the repository
            await _medicalRecordRepository.UpdateAsync(medicalRecord);

            return medicalRecord;
        }
    }
}
