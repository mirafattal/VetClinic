using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.InvoiceDTOs
{
    public class WeeklyRevenueDto
    {
        public DateTime PaymentDate { get; set; } // The specific date
        public decimal TotalAmount { get; set; } // Sum of all TotalAmount values for the date
    }
}
