using TaskManagementApi.DTOs;
namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto, int userId);
        Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(int userId , bool? completed, int page,int pageSize);
        Task<TaskResponseDto?> GetTaskAsync(int id, int userId);
        Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto, int userId);
        Task<bool> DeleteTaskAsync(int id, int userId);
    }
}
