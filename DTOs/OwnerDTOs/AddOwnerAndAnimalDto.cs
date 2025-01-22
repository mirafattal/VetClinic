using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.OwnerDTOs
{
    public class AddOwnerAndAnimalDto
    {
        public int OwnerId { get; set; }

        public string FullName { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string OwnerEmail { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime OwnerBirthDate { get; set; }
        public AnimalDto Animals { get; set; }
    }
}
