using Microsoft.AspNetCore.Mvc;
using Vet_BLL.DTOs;
using Vet_BLL.Services.Doctors;
using Vet_BLL.Services.Users;

namespace VetClinic.Controllers
{
    public class UserContoller : _GenericController<UserDto>
    {
        public readonly IUserService _userService;
        public UserContoller(IUserService service) : base(service)
        {
            _userService = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Call the service to register the user
                await _userService.RegisterUserAsync(userDto);

                return Ok(new { message = "User registered successfully" });
            }
            catch (Exception ex)
            {
                // Handle errors and return appropriate status codes
                return StatusCode(500, new { error = ex.Message });
            }
        }

        //[HttpPost("signup")]
        //public async Task<IActionResult> SignUp([FromBody] UserDto newUser)
        //{
        //    try
        //    {
        //        // Call the AddUserWithRoleAsync method
        //        await _userService.AddUserWithRoleAsync(newUser);
        //        return Ok(new { message = "User signed up successfully." });
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        // Handle invalid role error
        //        return BadRequest(new { error = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle other exceptions
        //        return StatusCode(500, new { error = "An unexpected error occurred.", details = ex.Message });
        //    }
        //}
    }
}
