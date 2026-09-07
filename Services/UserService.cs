//using TaskManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Data;
using TaskManagementApi.DTOs;
using TaskManagementApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskManagementApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        public UserService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto createUserDto)
        {
            var passwordHasher = new PasswordHasher<User>();
            var user = new User
            {
                UserName = createUserDto.UserName,
                UserEmail = createUserDto.UserEmail,
               
            };
            user.UserPassword = passwordHasher.HashPassword(user, createUserDto.UserPassword);
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


        public async Task<LoginResponseDto?> LoginUserAsync(LoginUserDto loginUserDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.UserEmail == loginUserDto.UserEmail);

            if (user == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<User>();

            var result = passwordHasher.VerifyHashedPassword(
                user,
                user.UserPassword,
                loginUserDto.UserPassword
            );

            if (result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var claims = new[]
{
    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
    new Claim(ClaimTypes.Email, user.UserEmail)
};

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };

          
        }
    
    
    
    
    }
}
