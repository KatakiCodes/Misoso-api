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
            user_id = userId;
            this.title = title;
            this.description = description;
            created_at = DateTime.UtcNow;
            to_finish_at = toFinishAt;
            is_focused = isFocused;
        }
        public TaskItem(int id, int userId, string title, string description, DateTime createdAt, DateTime? toFinishAt, DateTime? finishedAt, bool isFocused) : base(id)
        {
            user_id = userId;
            this.title = title;
            this.description = description;
            created_at = createdAt;
            to_finish_at = toFinishAt;
            finished_at = finishedAt;
            is_focused = isFocused;
        }

        public int user_id { get; private set; }
        public string title { get; private set; }
        public string? description { get; private set; }
        public DateTime created_at { get; private set; }
        public DateTime? to_finish_at { get; private set; }
        public DateTime? finished_at { get; private set; }
        public bool is_focused { get; private set; }

        public void UpdateTask(string title, string description)
        {
            this.title = title;
            this.description = description;
        }
        public void MasrkAsFocused()
        {
            is_focused = true;
        }
        public void DisableFocused()
        {
            is_focused = false;
        }
        public void Conclude()
        {
            finished_at = DateTime.Now;
        }
    }
}
