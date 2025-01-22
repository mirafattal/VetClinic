using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL.DTOs.OwnerDTOs;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.AnimalDTOs
{
    public class AnimalSearchDto
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public int OwnerId { get; set; }
        public string FullName { get; set; } = null!;

        public virtual OwnerDto Owner { get; set; } = null!;

    }
}
