using TaskManagementApi.DTOs;
namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto, int userid);
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(int userId);
        Task<TaskResponseDto?> GetTaskAsync(int id, int userId);
        Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
