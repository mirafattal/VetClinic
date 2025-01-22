using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_DAL.Models;

namespace Vet_BLL.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public DateTime? LastLogin { get; set; }

    }
}
