using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementApi.Services;
//using TaskManagementApi.Models;
using TaskManagementApi.DTOs;

namespace TaskManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask(CreateTaskDto createTaskDto) {

            var task = await _taskService.CreateTaskAsync(createTaskDto);
            return Created("", task);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var result = await _taskService.GetAllTasksAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var result = await _taskService.GetTaskAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDto updateTaskDto)
        {
            var result = await _taskService.UpdateTaskAsync(id, updateTaskDto);
            if(result == false)
            {
                return NotFound();
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return NoContent();
        }




    }
}
