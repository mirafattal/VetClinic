using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class DoctorSlot
{
    public int DoctorSlotId { get; set; }

    public int StaffId { get; set; }

    public DateOnly? SlotDate { get; set; }

    public TimeOnly? SlotStartTime { get; set; }

    public TimeOnly? SlotEndTime { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Staff Staff { get; set; } = null!;
}
