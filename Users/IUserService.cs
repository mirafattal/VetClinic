using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.Rapping;

namespace Vet_BLL.Services.Users
{
    public interface IUserService: IGenericService<UserDto>
    {
        public UserDto GetUserbyUsername(string username);
        public bool Login(LoginRequestDto loginRequestDto);

        Task<bool> IsEmailRegisteredAsync(string email);
        Task RegisterUserAsync(UserDto userDto);
        //public Task AddUserWithRoleAsync(UserDto newUser);
        public Task<AuthResponseDto> AuthenticateUserAsync(string username, string password);

        //public Task<ApiResponse<AuthResponseDto>> LoginUserAsync(LoginRequestDto loginDto);
    }
}
