using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs
{
    public class VaccinationDto
    {
        public int VaccinationId { get; set; }

        public int AnimalId { get; set; }

        public int? VaccineTypeId { get; set; }

        public DateTime VaccinationDate { get; set; }

        public DateTime NextDueDate { get; set; }

        public int StaffId { get; set; }

    }
}
