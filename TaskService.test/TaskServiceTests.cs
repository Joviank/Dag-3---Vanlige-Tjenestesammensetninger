namespace TaskService.test;

using Xunit;
using System.Linq;

public class TaskServiceTests
{
    [Fact]
    public void AddTask_ShouldAddTaskToList()
    {
        // Arrange
        var service = new TaskService();

        // Act
        service.AddTask("Eat pizza");

        Assert.Single(service.GetTasks());
    }

    [Fact]
    public void AddTask_ShouldStoreCorrectTitle()
    {
        // Arrange
        var service = new TaskService();

        // Act
        service.AddTask("To learn TDD");

        // Assert
        var task = service.GetTasks().First();
        Assert.Equal("To learn TDD", task.Title);
    }
    [Fact]
    public void CompleteTask_ShouldMarkTaskAsCompleted()
    {
        // Arrange
        var service = new TaskService();
        var task = service.AddTask("Wash the car");

        // Act
        service.CompleteTask(task.Id);

        // Assert
        Assert.True(service.GetTasks().First().IsCompleted);
    }

    [Fact]
    public void CompleteTask_ShouldThrow_WhenTaskDoesNotExist()
    {
        // Arrange 
        var service = new TaskService();

        // Act & Assert
        Assert.Throws<KeyNotFoundException>(() => service.CompleteTask(500));
    }

    [Fact]
    public void DeleteTask_ShouldRemoveTask()
    {
        // Arrange
        var service = new TaskService();
        var task = service.AddTask("Do stuff");

        // Act
        service.DeleteTask(task.Id);

        // Assert
        Assert.Empty(service.GetTasks());
    }
    [Fact]
    public async Task HTTPHealth_ReturnsOk()
    {
        var client = new HttpClient();

        var response = await client.GetAsync("http://localhost:5086/health");

        Assert.True(response.IsSuccessStatusCode);
    }
}
