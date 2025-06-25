using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesTodoList.Exceptions;
using RazorPagesTodoList.Services;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTodoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITaskService _taskService;

        public IndexModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public bool ShouldShowNewTaskForm { get; set; } = false;

        [BindProperty(Name = "error", SupportsGet = true)]
        public string? ErrorMessage { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Задача обязательно должна иметь название")]
        [MinLength(3, ErrorMessage = "Минимальная длинна названия задачи - 3 символа")]
        [MaxLength(32, ErrorMessage = "Максимальная длинна названия задачи - 32 символа")]
        public required string Name { get; set; }

        [BindProperty]
        [StringLength(256, ErrorMessage = "Максимальная длинна описания задачи - 256 символов")]
        public string? Description { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ShouldShowNewTaskForm = true;
                return Page();
            }

            _taskService.CreateTask(Name, Description);

            return RedirectToPage("/Index");
        }

        public IActionResult OnGetChangeTaskStatus(int taskId)
        {
            try
            {
                _taskService.ChangeTaskStatus(taskId);
            }
            catch (TaskNotFoundException)
            {
                return RedirectToPage("/Index", new { error = "Некорректный идентификатор задачи" });
            }

            return RedirectToPage("/Index");
        }

        public IActionResult OnGetDeleteTask(int taskId)
        {
            _taskService.DeleteTask(taskId);
            return RedirectToPage("/Index");
        }
    }
}
