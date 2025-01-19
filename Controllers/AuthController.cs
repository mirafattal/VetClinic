using System;
using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Rapping;
using Vet_BLL.Services.Auth;
using Vet_BLL.Services.Users;

namespace VetClinic.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        [HttpPost]
        public ApiResponse<bool> LoginOld(LoginRequestDto loginRequestdto)
        {
            return _authService.Login(loginRequestdto);
        }

        [HttpPost("authh")]
        public async Task<ApiResponse<AuthResponseDto>> auth(LoginRequestDto loginRequestDto)
        {
            ApiResponse<AuthResponseDto> response = new ApiResponse<AuthResponseDto>();
            AuthResponseDto loginRespondDto = new AuthResponseDto();
            AuthResponseDto user = await _userService.AuthenticateUserAsync(loginRequestDto.Username,
            loginRequestDto.Password);
            response.Data = user;
            //if (user == null) return Unauthorized("Invalid username or password");
            return response;
        }


        [HttpPost("login")]
        public async Task<ApiResponse<AuthResponseDto>> Login(LoginRequestDto loginRequestDto)
        {
            ApiResponse<AuthResponseDto> response = new ApiResponse<AuthResponseDto>();
            AuthResponseDto loginRespondDto = new AuthResponseDto();
            AuthResponseDto user = await _userService.AuthenticateUserAsync(loginRequestDto.Username,
            loginRequestDto.Password);
            response.Data = user;
            //if (user == null) return Unauthorized("Invalid username or password");
            return response;
        }
        












        //[HttpPost("login")]
        //[ProducesResponseType(typeof(ApiResponse<AuthResponseDto>), 200)]  // Success response
        //[ProducesResponseType(typeof(ApiResponse<string>), 401)]          // Unauthorized response
        //public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
        //{
        //    var authResponse = await _userService.LoginUserAsync(loginDto);

        //    if (!authResponse.Success) // Check the `Success` property from ApiResponse
        //    {
        //        return Unauthorized(new ApiResponse<string>
        //        {
        //            Success = false,
        //            ErrorMessage = authResponse.ErrorMessage ?? "Invalid credentials"
        //        });
        //    }
        //    // Return the AuthResponseDto wrapped in an ApiResponse with success set to true
        //    var response = new ApiResponse<AuthResponseDto>();
        //    return Ok(response);  // Return the success response with the AuthResponseDto
        //}


    }
}
