using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int? UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int StaffRoleId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorSchedule> DoctorSchedules { get; set; } = new List<DoctorSchedule>();

    public virtual ICollection<DoctorSlot> DoctorSlots { get; set; } = new List<DoctorSlot>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual StaffRole StaffRole { get; set; } = null!;

    public virtual User? User { get; set; }

    public virtual ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();
}
