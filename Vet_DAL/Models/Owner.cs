using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Owner
{
    public int OwnerId { get; set; }

    public int? UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string OwnerEmail { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public DateTime OwnerBirthDate { get; set; }

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();

    public virtual User? User { get; set; }
}
