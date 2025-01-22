using System;
using System.Collections.Generic;

namespace Vet_DAL.Models;

public partial class Inventory
{
    public int ItemId { get; set; }

    public string ItemName { get; set; } = null!;

    public int Quantity { get; set; }

    public DateTime LastRestocked { get; set; }

    public decimal UnitPrice { get; set; }
}
