using RazorPagesTodoList.Models;

namespace RazorPagesTodoList.Services
{
    public interface ITaskService
    {
        List<UserTask> GetTasks();
    }
}
