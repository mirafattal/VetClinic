using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.Rapping;

namespace Vet_BLL.Services.Auth
{
    public interface IAuthService
    {
       ApiResponse<bool> Login(LoginRequestDto login);
    }
}
