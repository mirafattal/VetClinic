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
using Vet_BLL.DTOs;
using Vet_DAL.Models;
using Vet_DAL.Repositories.Users;

namespace Vet_BLL.JWT
{
    public class JwtTokenGenerator: IJwtTokenGenerator
    {
        public readonly IUserRepository _userRepository;
        public readonly IConfiguration _configuration;

        public JwtTokenGenerator(IUserRepository userRepository, IConfiguration configuration)
           
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> GenerateTokenAsync(LoginRequestDto loginRequest)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);
            if (user == null)
            {
                throw new ArgumentException("Invalid username");
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim("UserId", user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(90),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
