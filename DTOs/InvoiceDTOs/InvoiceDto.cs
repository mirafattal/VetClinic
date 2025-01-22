using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.InvoiceDTOs
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }

        public string OwnerName { get; set; } = null!;

        public string? OwnerNumber { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}
