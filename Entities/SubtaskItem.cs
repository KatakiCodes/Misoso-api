using System.ComponentModel.DataAnnotations.Schema;

namespace Misoso.api.Entities
{
    [Table("Subtasks")]
    public class SubtaskItem : BaseEntity
    {
        public SubtaskItem()
        {}
        public SubtaskItem(int taskId, string title, bool isFocused)
        {
            task_id = taskId;
            this.title = title;
            created_at = DateTime.UtcNow;
            is_focused = isFocused;
            is_concluded = false;
        }
        public SubtaskItem(int id, int taskId, string title, DateTime createdAt, bool isFocused, bool isConcluded) : base(id)
        {
            task_id = taskId;
            this.title = title;
            created_at = createdAt;
            is_focused = isFocused;
            is_concluded = isConcluded;
        }
        public int task_id { get; private set; }
        public string title { get; private set; }
        public DateTime created_at { get; private set; }
        public bool is_focused { get; private set; }
        public bool is_concluded { get; private set; }

        public void UpdateSubtask(string title)
        {
            this.title = title;
        }
        public void ConcludeSubtask()
        {
            is_concluded = true;
        }
        public void MarkAsFocused()
        {
            is_focused = true;
        }
        public void DisableFocused()
        {
            is_focused = false;
        }
    }
}
