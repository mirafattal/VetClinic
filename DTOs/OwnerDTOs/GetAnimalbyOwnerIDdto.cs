using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL.DTOs.AnimalDTOs;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.OwnerDTOs
{
    public class GetAnimalbyOwnerIDdto
    {

        public int OwnerId { get; set; }
        public List<AnimalDto> Animals { get; set; }
    }
}
