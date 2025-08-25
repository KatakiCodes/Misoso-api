using Misoso.api.Entities;

namespace Misoso.Api.DTOs.Responses
{
    public record SubtaskItemResponse
    {
        public SubtaskItemResponse()
        {}
        public SubtaskItemResponse(int id, int taskItemId, DateTime created_at, string title, bool isFocused, bool isConcluded)
        {
            Id = id;
            TaskItemId = taskItemId;
            Title = title;
            CreatedAt = created_at;
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
            return new SubtaskItemResponse(entity.id, entity.task_id, entity.created_at, entity.title, entity.is_focused, entity.is_concluded);
        }
        public void Dispose()
        {}
    }
}
