using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class VaccinationWithVaccineTypeDto
    {
        public int VaccinationId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string Dose { get; set; }
        public DateTime NextDueDate { get; set; }
    }
}
