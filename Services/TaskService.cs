using TaskManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;
using TaskManagementApi.DTOs;

namespace TaskManagementApi.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _appDbContext;
        public TaskService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            var task = new TaskItem
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description
            };
            await _appDbContext.Tasks.AddAsync(task);
            await _appDbContext.SaveChangesAsync();
            return new TaskResponseDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt,
                UserId = task.UserId
            };
        }

        public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync()
        {
            var result = await _appDbContext.Tasks.Select(t => new TaskResponseDto
            {
                TaskId = t.TaskId,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt,
                UserId = t.UserId
            }).ToListAsync();
            return result;
        }

        public async Task<TaskResponseDto?> GetTaskAsync(int id)
        {
            var result = await _appDbContext.Tasks.FindAsync(id);
            if (result == null)
            {
                return null;
            }
            return new TaskResponseDto
            {
                TaskId = result.TaskId,
                Title = result.Title,
                Description = result.Description,
                IsCompleted = result.IsCompleted,
                CreatedAt = result.CreatedAt,
                UserId = result.UserId
            };
        }


        public async Task<bool> UpdateTaskAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var existing = await _appDbContext.Tasks.FindAsync(id);
            if (existing == null)
            {
                return false;
            }
            existing.Title = updateTaskDto.Title;
            existing.Description = updateTaskDto.Description;
            existing.IsCompleted = updateTaskDto.IsCompleted;
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
