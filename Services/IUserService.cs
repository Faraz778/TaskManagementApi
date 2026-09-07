//using TaskManagementApi.Models;
using TaskManagementApi.DTOs;

namespace TaskManagementApi.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto?> GetUserAsync(int id);   
        Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUserDto);
        Task<bool> DeleteUserAsync(int id);
        Task<LoginResponseDto?> LoginUserAsync(LoginUserDto loginUserDto);
    }
}
