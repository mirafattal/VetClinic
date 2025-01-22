using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.DoctorSchedules
{
    public class DoctorScheduleRepository : GenericRepository<DoctorSchedule>, IDoctorScheduleRepository
    {
        readonly private VetClinicContext _context;
        public DoctorScheduleRepository(VetClinicContext vetClinicContext) : base(vetClinicContext)
        {
            _context = vetClinicContext;
        }

        public IEnumerable<DoctorSchedule> GetSchedulesByDoctorAndDay(int doctorId, int dayOfWeek)
        {
            return _context.DoctorSchedules
                .Where(ds => ds.StaffId == doctorId && ds.DayOfWeek == dayOfWeek)
                .ToList();
        }

        public IEnumerable<DoctorSchedule> GetDoctorSchedule(int doctorId)
        {
            return _context.DoctorSchedules
                .Where(ds => ds.StaffId == doctorId)
                .ToList();
        }
    }
}
