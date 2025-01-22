using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_DAL.Models;

namespace Vet_BLL.Services.MedicalRecords
{
    public interface IMedicalRecordService: IGenericService<MedicalRecordDto>
    {
        List<MedicalRecordDto> GetMedicalRecordsByAnimalId(int animalId);
        Task<MedicalRecord> UpdateMedicalRecordAsync(MedicalRecordDto updateDto);

    }
}
