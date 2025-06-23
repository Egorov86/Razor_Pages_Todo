using RazorPagesTodoList.Exceptions;
using RazorPagesTodoList.Models;

namespace RazorPagesTodoList.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly List<UserTask> _tasks;
        private int _nextTaskId;

        public TaskService()
        {
            _tasks = new List<UserTask>();
            _nextTaskId = 1;
        }

        public List<UserTask> GetTasks()
        {
            return _tasks;
        }

        public void CreateTask(string name, string? description)
        {
            UserTask task = new UserTask()
            {
                Id = _nextTaskId++,
                Name = name,
                Description = description
            };

            _tasks.Add(task);
        }

        public UserTask? GetTaskById(int id)
        {
            foreach (UserTask task in _tasks)
            {
                if (task.Id == id)
                    return task;
            }

            return null;
        }

        public void ChangeTaskStatus(int id)
        {
            UserTask? task = GetTaskById(id);

            if (task == null)
                throw new TaskNotFoundException(id);

            task.IsDone = !task.IsDone;
        }
    }
}
