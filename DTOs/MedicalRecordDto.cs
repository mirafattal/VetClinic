using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs
{
    public class MedicalRecordDto
    {
        public int MedicalRecordId { get; set; }

        public int AnimalId { get; set; }

        public int StaffId { get; set; }

        public string Diagnosis { get; set; } = null!;

        public string Treatment { get; set; } = null!;

        public string SurgeryDetails { get; set; } = null!;

        public string PrescribedMedication { get; set; } = null!;

        public DateTime CreatedAt { get; set; }


    }
}
