using Microsoft.AspNetCore.Mvc;
using TaskService;
using TaskService.Api.DTO;

namespace TaskService.Api.Controllers;

[ApiController]
[Route("tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService= taskService;
    }

    [HttpGet]
    public IEnumerable<TaskItem> GetTask() {
        return _taskService.GetTasks();
    }

    [HttpPost]
    public TaskItem AddTask([FromBody] CreateTaskRequest request)
    {
        return _taskService.AddTask(request.Title);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        _taskService.DeleteTask(id);
        return NoContent();
    }

    [HttpPatch("{id}/complete")]
    public IActionResult CompleteTask(int id)
    {
        _taskService.CompleteTask(id);
        return NoContent();
    }
}