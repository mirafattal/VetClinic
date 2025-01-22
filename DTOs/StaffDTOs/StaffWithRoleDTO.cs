using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs.StaffDTOs
{
    public class StaffWithRoleDTO
    {
        public int StaffId { get; set; }

        public string FullName { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string Address { get; set; } = null!;
        public int StaffRoleId { get; set; }
        public string RoleName { get; set; }
    }
}
