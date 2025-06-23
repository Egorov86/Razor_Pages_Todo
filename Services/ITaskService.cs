using RazorPagesTodoList.Models;

namespace RazorPagesTodoList.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();
        void CreateTask(string name, string? description);
        UserTask? GetTaskById(int id);
        void ChangeTaskStatus(int id);
    }
}
