using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Protocol;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.ZLabResults
{
    public class ZLabResultRepository: GenericRepository<ZlabResult>, IZLabResultRepository
    {
        private readonly VetClinicContext _context;
        public ZLabResultRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public List<ZlabResult> GetResultByAnimalId(int animalId)
        {
            // Retrieve medical records for the given AnimalId
            return _context.ZlabResults
                           .Where(a => a.AnimalId == animalId) // Filtering by AnimalId
            .ToList();
        }

        public async Task<ZlabResult> AddLabResultAsync(ZlabResult labResult)
        {
            await _context.ZlabResults.AddAsync(labResult);
            await _context.SaveChangesAsync();
            return labResult;
        }
    }
}
