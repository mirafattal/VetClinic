using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Vet_BLL.DTOs;
using Vet_BLL.Exceptions;
using Vet_BLL.Rapping;
using Vet_DAL.Repositories.Users;

namespace Vet_BLL.Services.Auth
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ApiResponse<bool> Login(LoginRequestDto login)
        {
            var user = _userRepository.GetUserbyUsername(login.Password);
            if (user == null)
            {
                throw new NotFoundException("Username not found");
            }
            if (login.Password == null)
            {
                throw new NotFoundException("Wrong password");
            }
            return new ApiResponse<bool>(true);
        }
    }
}
