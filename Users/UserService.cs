using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vet_BLL._GenericService;
using Vet_BLL.DTOs;
using Vet_BLL.JWT;
using Vet_BLL.Rapping;
using Vet_BLL.Services.Appointments;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Appointments;
using Vet_DAL.Repositories.Users;

namespace Vet_BLL.Services.Users
{
    public class UserService: GenericService<User, UserDto>, IUserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository userRepository, IMapper mapper, 
            IJwtTokenGenerator jwtTokenGenerator) :
            base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public UserDto GetUserbyUsername(string username)
        {
            var result = _userRepository.GetUserbyUsername(username);
            return _mapper.Map<UserDto>(result);
        }

        public bool Login(LoginRequestDto loginRequestDto)
        {
            var username = loginRequestDto.Username;
            var user = _userRepository.GetUserbyUsername(username);

            if (user == null)
            {
                return false;
            }
            else if (user.Password == loginRequestDto.Password)
            {

                return true;

            }
            return false;
        }

        public async Task<bool> IsEmailRegisteredAsync(string email)
        {
            return await _userRepository.IsEmailRegisteredAsync(email);
        }

        public async Task RegisterUserAsync(UserDto userDto)
        {
            // Map UserDto to User entity
            var user = _mapper.Map<User>(userDto);

            // Store the password directly (no hashing)
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.FullName = userDto.FullName;
            user.Password = userDto.Password;
            user.Role = userDto.Role;
            user.CreatedAt = DateTime.UtcNow;

            // Save user to the database
            await _userRepository.AddUserAsync(user);
        }



        public async Task<AuthResponseDto> AuthenticateUserAsync(string username, string password)
        {
            //Fetch the user from the repository
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(user.Password, password))
            {
                return null;
            }

            //Map the user to the LoginRequestdto
            var userResponse = new AuthResponseDto
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,

            };
            //Generate JWT token
            var token = await _jwtTokenGenerator.GenerateTokenAsync(new LoginRequestDto
            {
                Username = user.Username,
                Password = user.Password
            });

            // Add the token to the response
            userResponse.Token = token;
            return userResponse;

        }

        private bool VerifyPassword(string storedPassword, string inputPassword)
        {
            return storedPassword == inputPassword;
        }



        //public async Task AddUserWithRoleAsync(UserDto newUser)
        //{
        //    var role = await _userRoleRepository.GetUserRoleByRoleNameAsync(newUser.UserRole.RoleName);
        //    if (role == null) 
        //    {
        //        throw new ArgumentException($"Genre ' {newUser.UserRole.RoleName}' does not exist.");
        //    }
        //    var user = _mapper.Map<User>(newUser);
        //    user.UserRoleId = role.UserRoleId;
        //    await _userRepository.AddUserAsync(user);
        //}





















        //// Validate user credentials for login
        //public async Task<ApiResponse<AuthResponseDto>> LoginUserAsync(LoginRequestDto loginDto)
        //{
        //    var user = await _userRepository.GetUserByUsernameAsync(loginDto.Username);
        //    if (user == null)
        //    {
        //        return new ApiResponse<AuthResponseDto>
        //        {
        //            Success = false,
        //            ErrorMessage = "User not found"
        //        };
        //    }

        //    // Compare passwords (for now, directly)
        //    if (user.Password != loginDto.Password)
        //    {
        //        return new ApiResponse<AuthResponseDto>
        //        {
        //            Success = false,
        //            ErrorMessage = "Invalid password"
        //        };
        //    }

        //    // Generate JWT if credentials are valid
        //    var accessToken = GenerateJwtToken(user);
        //    var refreshToken = GenerateRefreshToken();

        //    var authResponse = new AuthResponseDto
        //    {
        //        Token = accessToken,
        //        RefreshToken = refreshToken
        //    };

        //    return new ApiResponse<AuthResponseDto>(authResponse); // Wrap in ApiResponse
        //}

        // Generate JWT token
//        private string GenerateJwtToken(User user)
//        {
//            var secretKey = _configuration["Jwt:SecretKey"];
//            if (string.IsNullOrEmpty(secretKey))
//            {
//                throw new ArgumentNullException("Jwt SecretKey is not configured correctly.");
//            }

//            var claims = new List<Claim>
//{
//             new Claim(JwtRegisteredClaimNames.Sub, user.Username),
//             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//};

//            // Check if user.UserRole is not null and if RoleName is available
//            //if (user.UserRole != null && !string.IsNullOrEmpty(user.UserRole.RoleName))
//            //{
//            //    claims.Add(new Claim(ClaimTypes.Role, user.UserRole.RoleName));
//            //}
//            //else
//            //{
//            //    // Handle the case where RoleName is not available (e.g., set a default role or log an error)
//            //    claims.Add(new Claim(ClaimTypes.Role, "Patient")); // Replace with an appropriate default role
//            //}

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var token = new JwtSecurityToken(
//                issuer: _configuration["Jwt:Issuer"],
//                audience: _configuration["Jwt:Audience"],
//                claims: claims,
//                expires: DateTime.Now.AddMinutes(30),
//                signingCredentials: creds);

//            return new JwtSecurityTokenHandler().WriteToken(token);
//        }

//        private string GenerateRefreshToken()
//        {
//            var refreshToken = Guid.NewGuid().ToString();
//            // You can store the refresh token in your database or a cache
//            return refreshToken;
//        }
    }
}
