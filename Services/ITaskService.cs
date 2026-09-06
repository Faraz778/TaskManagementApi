using TaskManagementApi.DTOs;
namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto);
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync();
        Task<TaskResponseDto?> GetTaskAsync(int id);
        Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(int id);
    }
}
