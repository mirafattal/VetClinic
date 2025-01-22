using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.AnimalDTOs
{
    public class AnimalDto
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


    }
}
