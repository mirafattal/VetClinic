using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL._GenericRepository;
using Vet_DAL.Models;

namespace Vet_DAL.Repositories.DoctorSchedules
{
    public interface IDoctorScheduleRepository: IGenericRepository<DoctorSchedule>
    {
        public IEnumerable<DoctorSchedule> GetSchedulesByDoctorAndDay(int doctorId, int dayOfWeek);

        public IEnumerable<DoctorSchedule> GetDoctorSchedule(int doctorId);
    }
}
