using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public interface ITaskService
    {
        Task<TaskItem> CreateTaskAsync(TaskItem taskItem);
        Task<IEnumerable<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskAsync(int id);
        Task<bool> UpdateTaskAsync(int id, TaskItem taskItem);
        Task<bool> DeleteTaskAsync(int id);
    }
}
