using Misoso.api.Entities;

namespace Misoso.Api.DTOs.Responses
{
    public record SubtaskItemResponse
    {
        public SubtaskItemResponse()
        {}
        public SubtaskItemResponse(int id, int taskItemId, string title, bool isFocused, bool isConcluded)
        {
            Id = id;
            TaskItemId = taskItemId;
            Title = title;
            CreatedAt = DateTime.Today;
            IsFocused = isFocused;
            IsConcluded = isConcluded;
        }

        public int Id { get; private set; }
        public int TaskItemId { get; private set; }
        public string Title { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsFocused { get; private set; }
        public bool IsConcluded { get; private set; }

        public SubtaskItemResponse ToResponseDto(SubtaskItem entity)
        {
            return new SubtaskItemResponse(entity.Id, entity.Task_Id, entity.Title, entity.Is_Focused, entity.Is_Concluded);
        }
        public void Dispose()
        {}
    }
}
