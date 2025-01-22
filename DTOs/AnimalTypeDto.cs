using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class AnimalTypeDto
    {
        public int AnimalTypeId { get; set; }

        public string TypeName { get; set; } = null!;
    }
}
