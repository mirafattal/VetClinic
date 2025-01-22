using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public string OwnerName { get; set; } = null!;

    public string OwnerNumber { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime PaymentDate { get; set; }
}
