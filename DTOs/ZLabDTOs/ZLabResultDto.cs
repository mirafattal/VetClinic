using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.ZLabDTOs
{
    public class ZLabResultDto
    {
        public int LabResultId { get; set; }

        public int AnimalId { get; set; }

        public string TestName { get; set; } = null!;

        public DateTime TestDate { get; set; }

        public decimal Result { get; set; }

        public string? Notes { get; set; }

        public string? IsNormal { get; set; }

        public int TestNormalRangeId { get; set; }
    }
}
