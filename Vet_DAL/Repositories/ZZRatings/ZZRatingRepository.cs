using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.ZZRatings
{
    public class ZZRatingRepository: GenericRepository<Zzrating>, IZZRatingRepository
    {
        private readonly VetClinicContext _context;
        public ZZRatingRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public async Task<List<Zzrating>> GetLastThreeReviewsAsync()
        {
            // Retrieve and order reviews by created date in descending order (latest first)
            return await _context.Zzratings
                .OrderByDescending(r => r.CreatedAt)
                .Take(3)
                .ToListAsync(); // This extension method is from Microsoft.EntityFrameworkCore
        }
    }
}
