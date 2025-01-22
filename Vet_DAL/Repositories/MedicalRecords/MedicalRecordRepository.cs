using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.MedicalRecords
{
    public class MedicalRecordRepository : GenericRepository<MedicalRecord>, IMedicalRecordRepository
    {
        private readonly VetClinicContext _context;
        public MedicalRecordRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public List<MedicalRecord> GetMedicalRecordsByAnimalId(int animalId)
        {
            // Retrieve medical records for the given AnimalId
            return _context.MedicalRecords
                           .Where(mr => mr.AnimalId == animalId) // Filtering by AnimalId
                           .ToList();
        }
        public async Task<MedicalRecord> GetByIdAsync(int medicalRecordId)
        {
            return await _context.MedicalRecords
                                 .Where(m => m.MedicalRecordId == medicalRecordId)
                                 .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(MedicalRecord medicalRecord)
        {
            _context.MedicalRecords.Update(medicalRecord);
            await _context.SaveChangesAsync();
        }
    }
}
