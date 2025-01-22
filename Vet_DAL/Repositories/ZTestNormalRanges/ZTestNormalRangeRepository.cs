using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.ZTestNormalRanges
{
    public class ZTestNormalRangeRepository: GenericRepository<ZtestNormalRange>, IZTestNormalRangeRepository
    {
        private readonly VetClinicContext _context;

        public ZTestNormalRangeRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public async Task<ZtestNormalRange> GetTestNormalRangeByIdAsync(int testNormalRangeId)
        {
            return await _context.ZtestNormalRanges.FindAsync(testNormalRangeId);
        }
    }
}
