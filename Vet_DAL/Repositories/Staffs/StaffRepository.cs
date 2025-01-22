using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;

namespace Vet_DAL.Repositories.Doctors
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        private readonly VetClinicContext _context;
        public StaffRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public async Task<string> GetStaffNameAsync(int staffId)
        {
            var staff = await _context.Staff
                .Where(d => d.StaffId == staffId)
                .Select(d => d.FullName)
                .FirstOrDefaultAsync();

            return staff;
        }



        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            return await _context.Set<Staff>().FindAsync(id);
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            _context.Entry(staff).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }



    }
}

