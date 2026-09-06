//using TaskManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.DTOs;
using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                UserName = createUserDto.UserName,
                UserEmail = createUserDto.UserEmail,
                UserPassword = createUserDto.UserPassword
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return new UserResponseDto
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserEmail = user.UserEmail
            };
        }


       public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync()
        {

            var result = await _context.Users.Select(u => new UserResponseDto
            {
                UserId = u.UserId,
                UserName = u.UserName,
                UserEmail = u.UserEmail
            })
            .ToListAsync();
            return result;
        }

        public async Task<UserResponseDto?> GetUserAsync(int id)
        {
            var result = await _context.Users.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            return new UserResponseDto
            {
                UserId = result.UserId,
                UserName = result.UserName,
                UserEmail = result.UserEmail
            };
        }

        public async Task<bool> UpdateUserAsync(int id, UpdateUserDto updateUserDto)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return false;
            }
            existingUser.UserName = updateUserDto.UserName;
            existingUser.UserEmail = updateUserDto.UserEmail;
            existingUser.UserPassword = updateUserDto.UserPassword;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }


    }
}
