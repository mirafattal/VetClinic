using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class PetForAdoption
{
    public int PetForAdoptionId { get; set; }

    public string PetName { get; set; } = null!;

    public string Breed { get; set; } = null!;

    public string Species { get; set; } = null!;

    public DateOnly PetBirthDate { get; set; }

    public string PetCondition { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public decimal Weight { get; set; }

    public int AdoptionStatusId { get; set; }

    public string? ImageUrl { get; set; }

    public virtual ICollection<AdoptionQuestionnaire> AdoptionQuestionnaires { get; set; } = new List<AdoptionQuestionnaire>();

    public virtual AdoptionStatus AdoptionStatus { get; set; } = null!;
}
