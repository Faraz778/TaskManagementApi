using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs
{
    public class CreateUserDto
    {

        [Required]
        [MaxLength(30, ErrorMessage = "Username cannot exceed 30 characters.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string UserEmail { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string UserPassword { get; set; }
    }
}

