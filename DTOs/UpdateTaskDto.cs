using System.ComponentModel.DataAnnotations;

namespace TaskManagementApi.DTOs
{
    public class UpdateTaskDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "title cannot exceed 20 characters.")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
