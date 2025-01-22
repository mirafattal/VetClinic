using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs
{
    public class DoctorScheduleDto
    {
        public int DoctorScheduleId { get; set; }

        public int DayOfWeek { get; set; }

        public int StaffId { get; set; }

        public TimeOnly StartTimeSchedule { get; set; }

        public TimeOnly EndTimeSchedule { get; set; }

    }
}
