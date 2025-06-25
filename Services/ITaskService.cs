using RazorPagesTodoList.Models;

namespace RazorPagesTodoList.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();
        UserTask? GetTaskById(int id);
        void CreateTask(string name, string? description);
        void ChangeTaskStatus(int id);
        void DeleteTask(int id);
    }
}
