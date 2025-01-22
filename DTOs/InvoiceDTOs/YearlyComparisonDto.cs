using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.InvoiceDTOs
{
    public class YearlyComparisonDto
    {
        public int CurrentYear { get; set; }
        public decimal CurrentYearRevenue { get; set; }
        public int PreviousYear { get; set; }
        public decimal PreviousYearRevenue { get; set; }
        public decimal GrowthPercentage =>
         PreviousYearRevenue == 0
        ? (CurrentYearRevenue > 0 ? 100 : 0)
        : ((CurrentYearRevenue - PreviousYearRevenue) / PreviousYearRevenue) * 100;
    }
}
