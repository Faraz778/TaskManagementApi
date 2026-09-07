using System.ComponentModel.DataAnnotations;    


namespace TaskManagementApi.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "title cannot exceed 20 characters.")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
