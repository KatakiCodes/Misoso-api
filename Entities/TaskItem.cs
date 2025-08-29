using System.ComponentModel.DataAnnotations.Schema;

namespace Misoso.api.Entities
{
    [Table("Tasks")]
    public class TaskItem : BaseEntity
    {
        public TaskItem()
        { }
        public TaskItem(int userId, string title, string? description, DateTime? toFinishAt, bool isFocused)
        {
            User_id = userId;
            Title = title;
            Description = description;
            Created_at = DateTime.UtcNow;
            To_finish_at = toFinishAt;
            Is_focused = isFocused;
        }
        public TaskItem(int id, int userId, string title, string description, DateTime createdAt, DateTime? toFinishAt, DateTime? finishedAt, bool isFocused) : base(id)
        {
            User_id = userId;
            Title = title;
            Description = description;
            Created_at = DateTime.UtcNow;
            To_finish_at = toFinishAt;
            Is_focused = isFocused;
        }

        public int User_id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime Created_at { get; private set; }
        public DateTime? To_finish_at { get; private set; }
        public DateTime? Finished_at { get; private set; }
        public bool Is_focused { get; private set; }

        public void UpdateTask(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public void MasrkAsFocused()
        {
            Is_focused = true;
        }
        public void DisableFocused()
        {
            Is_focused = false;
        }
        public void Conclude()
        {
            Finished_at = DateTime.Now;
        }
    }
}
