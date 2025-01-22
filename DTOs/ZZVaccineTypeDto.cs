using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class ZZVaccineTypeDto
    {
        public int VaccineTypeId { get; set; }

        public string VaccineName { get; set; } = null!;

        public string Dose { get; set; } = null!;
    }
}
