using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class InventoryDto
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; } = null!;

        public int Quantity { get; set; }

        public DateTime LastRestocked { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
