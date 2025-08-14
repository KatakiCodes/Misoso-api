using Misoso.api.Entities;
using System.ComponentModel.DataAnnotations;

namespace Misoso.Api.DTOs.Requests
{
    public record UpdateTaskItemRequest
    {
        [Range(minimum:1, maximum: int.MaxValue, ErrorMessage = "Id inválido!")]
        public int Id { get; private set; }
        [Required(ErrorMessage = "O título da tarefa deve ser informado!")]
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public UpdateTaskItemRequest(int id, string title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
