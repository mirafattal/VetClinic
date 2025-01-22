using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class ZZratingDto
    {
        public int RatingId { get; set; }

        public string FullName { get; set; } = null!;

        public int? UserId { get; set; }

        public string ReviewTitle { get; set; } = null!;

        public int RatingValue { get; set; }

        public string Review { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
