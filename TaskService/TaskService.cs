using TaskService.Repositories;
namespace TaskService;

public class TaskService
{
    private readonly ITaskRepository _repo;

    public TaskService(ITaskRepository repo)
    {
        _repo = repo;
    }

    public TaskItem AddTask(string title)
    {
        return _repo.Add(title);
    }

    public List<TaskItem> GetTasks()
    {
        return _repo.GetAll();
    }

    public void CompleteTask(int id)
    {
        _repo.Complete(id);
    }

    public void DeleteTask(int id)
    {
        _repo.Delete(id);
    }
}