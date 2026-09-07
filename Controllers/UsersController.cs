using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Services;
using TaskManagementApi.DTOs;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUserAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            var result = await _userService.CreateUserAsync(createUserDto);
            return Created("", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var result = await _userService.UpdateUserAsync(id, updateUserDto);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var result = await _userService.LoginUserAsync(loginUserDto);

            if (result == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            return Ok(result);
        }

    }
}
