using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL.DTOs;

namespace Vet_BLL.JWT
{
    public interface IJwtTokenGenerator
    {
        public Task<string> GenerateTokenAsync(LoginRequestDto loginRequest);
    }
}
