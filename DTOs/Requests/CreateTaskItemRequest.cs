using System.ComponentModel.DataAnnotations;

namespace Misoso.Api.DTOs.Requests
{
    public record CreateTaskItemRequest
    {
        [Required(ErrorMessage = "Referencie o utilizador!")]
        public int UserId { get; private set; }
        [Required(ErrorMessage = "O título da tarefa deve ser informado!")]
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime? ToFinishAt { get; private set; }
        public bool IsFocused { get; private set; }

        public CreateTaskItemRequest(int userId, string title, string? description, DateTime? toFinishAt, bool isFocused)
        {
            UserId = userId!;
            Title = title;
            Description = description;
            ToFinishAt = toFinishAt;
            IsFocused = isFocused;
        }
    }
}
