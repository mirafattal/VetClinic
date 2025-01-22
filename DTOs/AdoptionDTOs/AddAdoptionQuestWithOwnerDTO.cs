using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.AdoptionDTOs
{
    public class AddAdoptionQuestWithOwnerDTO
    {
        public int AdoptionQuestionnaireId { get; set; }

        public int UserId { get; set; }

        public string Occupation { get; set; } = null!;

        public int Salary { get; set; }

        public bool IsMarried { get; set; }

        public bool IsHouseholdAware { get; set; }

        public bool HasOwnedPetBefore { get; set; }

        public int PetForAdoptionId { get; set; }

        public string ReasonForAdoption { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public virtual OwnerDto Owner { get; set; } = null!;
    }
}
