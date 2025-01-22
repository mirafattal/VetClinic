using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.AppointmentDTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        public int AnimalId { get; set; }

        public int StaffId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public int DoctorSlotId { get; set; }

        public string AppointmentReason { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

    }
}
