using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class MedicalRecord
{
    public int MedicalRecordId { get; set; }

    public int AnimalId { get; set; }

    public int StaffId { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string Treatment { get; set; } = null!;

    public string SurgeryDetails { get; set; } = null!;

    public string PrescribedMedication { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
