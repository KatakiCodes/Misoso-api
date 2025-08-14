using System.ComponentModel.DataAnnotations;

namespace Misoso.Api.DTOs.Requests
{
    public record UpdateSubtaskItemRequest
    {
        [Range(minimum: 1, maximum: int.MaxValue, ErrorMessage = "Id invalido!")]
        public int Id { get; private set; }
        [Required(ErrorMessage = "O título da etapa deve ser informado!")]
        public string Title { get; private set; }

        public UpdateSubtaskItemRequest(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
