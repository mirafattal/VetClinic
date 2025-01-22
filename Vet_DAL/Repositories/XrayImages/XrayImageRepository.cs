using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.XrayImages
{
    public class XrayImageRepository: GenericRepository<XrayImage>, IXrayImageRepository
    {
        private readonly VetClinicContext _context;
        public XrayImageRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public async Task AddXrayAsync(XrayImage xray)
        {
            await _context.XrayImages.AddAsync(xray);
            await _context.SaveChangesAsync();
        }

        public async Task<List<XrayImage>> GetXRayByAnimalIdAsync(int animalId)
        {
            return await _context.XrayImages
                .Where(x => x.AnimalId == animalId)
                .ToListAsync();
        }
    }
}
