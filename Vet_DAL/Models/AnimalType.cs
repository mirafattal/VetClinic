using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class AnimalType
{
    public int AnimalTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Animal> Animals { get; set; } = new List<Animal>();
}
