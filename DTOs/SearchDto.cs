using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class SearchDto
    {
        public string SearchTerm { get; set; } = null;
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
