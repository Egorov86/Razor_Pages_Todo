namespace RazorPagesTodoList.Exceptions
{
    public class TaskNotFoundException : Exception
    {
        public int TaskId { get; private set; }

        public TaskNotFoundException(int taskId) : base($"Task with id {taskId} not found")
        {
            TaskId = taskId;
        }
    }
}
