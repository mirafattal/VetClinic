using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class AdoptionStatus
{
    public int AdoptionStatusId { get; set; }

    public string AdoptionStatusName { get; set; } = null!;

    public virtual ICollection<PetForAdoption> PetForAdoptions { get; set; } = new List<PetForAdoption>();
}
