using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vet_BLL.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } // The JWT token (access token)
        public string Username { get; set; } // Optional: Authenticated username
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; } = null!;
        public string Email { get; set; }
        public string Role { get; set; } = null!;
    }
}

