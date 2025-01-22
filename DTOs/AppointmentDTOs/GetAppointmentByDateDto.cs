using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.AppointmentDTOs
{
    public class GetAppointmentByDateDto
    {
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeOnly SlotStartTime { get; set; }
        public string AppointmentReason { get; set; }
        public int StaffId { get; set; }
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string FullName { get; set; }
        public string StaffName { get; set; }

    }
}
