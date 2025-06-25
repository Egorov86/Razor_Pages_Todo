using RazorPagesTodoList.Models;

namespace RazorPagesTodoList.Repositories
{
    public interface ITaskRepository
    {
        List<UserTask> GetAll();
        UserTask? GetById(int id);
        void Create(UserTask userTask);
        void Delete(int id);
        void SaveChanges();
    }
}
