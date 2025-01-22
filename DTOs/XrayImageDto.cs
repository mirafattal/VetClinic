using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class XrayImageDto
    {
        public int XrayId { get; set; }

        public string? ImageUrl { get; set; }

        public int AnimalId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
