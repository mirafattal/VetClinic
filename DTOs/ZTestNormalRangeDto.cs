using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class ZTestNormalRangeDto
    {
        public int TestNormalRangeId { get; set; }

        public string TestName { get; set; } = null!;

        public decimal MinRange { get; set; }

        public decimal MaxRange { get; set; }

        public string UnitOfMeasurement { get; set; } = null!;
    }
}
