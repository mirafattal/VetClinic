using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vet_BLL.DTOs.AdoptionDTOs
{
    public class AddPetForAdoptionDto
    {
        public int PetForAdoptionId { get; set; }

        public string Breed { get; set; } = null!;

        public string Species { get; set; } = null!;

        public DateOnly PetBirthDate { get; set; }

        public string PetCondition { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public decimal Weight { get; set; }

        public int AdoptionStatusId { get; set; }

        public string PetName { get; set; } = null!;

        public string ImageUrl { get; set; }  // The image file uploaded
    }
}
