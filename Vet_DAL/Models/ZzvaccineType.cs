using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class ZzvaccineType
{
    public int VaccineTypeId { get; set; }

    public string VaccineName { get; set; } = null!;

    public string Dose { get; set; } = null!;

    public virtual ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
