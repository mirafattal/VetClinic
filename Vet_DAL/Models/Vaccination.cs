using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Vaccination
{
    public int VaccinationId { get; set; }

    public int AnimalId { get; set; }

    public DateTime VaccinationDate { get; set; }

    public DateTime NextDueDate { get; set; }

    public int StaffId { get; set; }

    public int? VaccineTypeId { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;

    public virtual ZzvaccineType? VaccineType { get; set; }
}
