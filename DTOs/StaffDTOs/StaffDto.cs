using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs.DoctorDTOs
{
    public class StaffDto
    {
        public int StaffId { get; set; }

        public int? UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int StaffRoleId { get; set; }


    }
}
