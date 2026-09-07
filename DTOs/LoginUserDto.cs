using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        public string UserPassword { get; set; }
    }
    }
