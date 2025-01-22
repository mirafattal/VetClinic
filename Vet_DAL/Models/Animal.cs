using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Animal
{
    public int AnimalId { get; set; }

    public int OwnerId { get; set; }

    public int AnimalTypeId { get; set; }

    public string AnimalName { get; set; } = null!;

    public string Species { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime AnimalBirthDate { get; set; }

    public decimal Weight { get; set; }

    public string? ImageUrl { get; set; }

    public virtual AnimalType AnimalType { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

    public virtual Owner Owner { get; set; } = null!;

    public virtual ICollection<Vaccination> Vaccinations { get; set; } = new List<Vaccination>();

    public virtual ICollection<XrayImage> XrayImages { get; set; } = new List<XrayImage>();

    public virtual ICollection<ZlabResult> ZlabResults { get; set; } = new List<ZlabResult>();
}
