using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.DoctorSlotsDTOs
{
    public class DoctorSlotDto
    {
        public int DoctorSlotId { get; set; }

        public int StaffId { get; set; }

        public DateOnly? SlotDate { get; set; }

        public TimeOnly? SlotStartTime { get; set; }

        public TimeOnly? SlotEndTime { get; set; }

    }
}
