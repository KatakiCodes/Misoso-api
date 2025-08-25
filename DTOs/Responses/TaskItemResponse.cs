using Misoso.api.Entities;

namespace Misoso.Api.DTOs.Responses
{
    public record TaskItemResponse
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? ToFinishAt { get; private set; }
        public DateTime? FinishedAt { get; private set; }
        public bool IsFocused { get; private set; }

        public TaskItemResponse()
        {}
        public TaskItemResponse(int id,int userId, string title, string description, DateTime createdAt, DateTime? toFinishAt, DateTime? finishedAt, bool isFocused)
        {
            Id = id;
            UserId = userId;
            Title = title;
            Description = description;
            CreatedAt = createdAt;
            ToFinishAt = toFinishAt;
            FinishedAt = finishedAt;
            IsFocused = isFocused;
        }

        public TaskItemResponse? ToResponseDto(TaskItem? entity)
        {
            return (entity is null) ? null : new TaskItemResponse(entity.id, entity.user_id, entity.title, entity.description, entity.created_at, entity.to_finish_at, entity.finished_at, entity.is_focused);
        }

        public void Dispose()
        {}
    }
}
