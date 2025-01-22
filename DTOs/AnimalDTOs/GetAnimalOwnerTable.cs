using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.AnimalDTOs
{
    public class GetAnimalOwnerTable
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

        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string OwnerEmail { get; set; } = null!;
        public DateTime OwnerBirthDate { get; set; }

        public string Phone { get; set; } = null!;
    }
}
