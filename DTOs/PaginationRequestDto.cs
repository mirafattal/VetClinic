using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class PaginationRequestDto
    {
        public int PageNumber { get; set; } = 1; // Default to the first page
        public int PageSize { get; set; } = 20; // Default page size
    }
}
