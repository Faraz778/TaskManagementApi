using TaskManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;

namespace TaskManagementApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _appDbContext;
        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem taskItem)
        {
            await _appDbContext.Tasks.AddAsync(taskItem);
            await _appDbContext.SaveChangesAsync();
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            var result = await _appDbContext.Tasks.ToListAsync();
            return result;
        }

        public async Task<TaskItem?> GetTaskAsync(int id)
        {
            var result = await _appDbContext.Tasks.FindAsync(id);
            return result;
        }


        public async Task<bool> UpdateTaskAsync(int id, TaskItem taskItem)
        {
            var existing = await _appDbContext.Tasks.FindAsync(id);
            if (existing == null)
            {
                return false;
            }
            existing.Title = taskItem.Title;
            existing.Description = taskItem.Description;
            existing.IsCompleted = taskItem.IsCompleted;
           await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var existingTask = await _appDbContext.Tasks.FindAsync(id);
            if (existingTask == null)
            {
                return false;
            }
            _appDbContext.Tasks.Remove(existingTask);
            await _appDbContext.SaveChangesAsync();
            return true;
        }








    }
}
