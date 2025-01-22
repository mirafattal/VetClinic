using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.MedicalRecords
{
    public interface IMedicalRecordRepository: IGenericRepository<MedicalRecord>
    {
        List<MedicalRecord> GetMedicalRecordsByAnimalId(int animalId);
        Task<MedicalRecord> GetByIdAsync(int medicalRecordId);
        Task UpdateAsync(MedicalRecord medicalRecord);
    }
}
