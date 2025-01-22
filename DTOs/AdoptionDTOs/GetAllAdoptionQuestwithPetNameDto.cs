using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.AdoptionDTOs
{
    public class GetAllAdoptionQuestwithPetNameDto
    {
        public int AdoptionQuestionnaireId { get; set; }

        public int? UserId { get; set; }

        public string Occupation { get; set; } = null!;

        public int Salary { get; set; }

        public bool IsMarried { get; set; }

        public bool HasChildren { get; set; }

        public bool IsHouseholdAware { get; set; }

        public bool HasOwnedPetBefore { get; set; }

        public int PetForAdoptionId { get; set; }

        public bool HasAllergiesAsthma { get; set; }

        public string WhoWillBeReponsible { get; set; } = null!;

        public string LeftAlone { get; set; } = null!;

        public string IfSick { get; set; } = null!;

        public string ReasonForAdoption { get; set; } = null!;

        public string QuestionStatus { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public string PetName { get; set; }
    }
}
