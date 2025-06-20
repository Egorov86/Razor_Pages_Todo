using RazorPagesTodoList.Models;

namespace RazorPagesTodoList.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks;

        public TaskService()
        {
            _tasks = new List<UserTask>();
        }

        public List<UserTask> GetTasks()
        {
            return _tasks;
        }
    }
}
