using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.OwnerDTOs
{
    public class OwnerDto
    {
        public int OwnerId { get; set; }
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string OwnerEmail { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public DateTime OwnerBirthDate { get; set; }
    }
}
