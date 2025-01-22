using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int AnimalId { get; set; }

    public int StaffId { get; set; }

    public DateTime AppointmentDate { get; set; }

    public int DoctorSlotId { get; set; }

    public string AppointmentReason { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Animal Animal { get; set; } = null!;

    public virtual DoctorSlot DoctorSlot { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
