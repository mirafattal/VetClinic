using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class DoctorSchedule
{
    public int DoctorScheduleId { get; set; }

    public int DayOfWeek { get; set; }

    public int StaffId { get; set; }

    public TimeOnly StartTimeSchedule { get; set; }

    public TimeOnly EndTimeSchedule { get; set; }

    public virtual Staff Staff { get; set; } = null!;
}
