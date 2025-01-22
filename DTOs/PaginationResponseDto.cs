using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class PaginationResponseDto<T>
    {
        public IEnumerable<T> Data { get; set; } // Paginated data
        public int TotalRecords { get; set; }   // Total number of records in the table
        public int PageNumber { get; set; }     // Current page number
        public int PageSize { get; set; }       // Number of records per page
    }
}
