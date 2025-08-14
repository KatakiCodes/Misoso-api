using System.ComponentModel.DataAnnotations;

namespace Misoso.Api.DTOs.Requests
{
    public record CreateSubtaskItemRequest
    {
        [Required(ErrorMessage = "Referencie a tarefa!")]
        public int TaskItemId { get; private set; }
        [Required(ErrorMessage = "O título da etapa deve ser informado!")]
        public string Title { get; private set; }
        public bool IsFocused { get; private set; }

        public CreateSubtaskItemRequest(int taskItemId, string title, bool isFocused)
        {
            TaskItemId = taskItemId!;
            Title = title;
            IsFocused = isFocused;
        }
    }
}
