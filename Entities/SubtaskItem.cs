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
            Task_id = taskId;
            Title = title;
            Created_at = DateTime.UtcNow;
            Is_focused = isFocused;
            Is_concluded = false;
        }
        public SubtaskItem(int id, int taskId, string title, DateTime createdAt, bool isFocused, bool isConcluded) : base(id)
        {
            Task_id = taskId;
            Title = title;
            Created_at = DateTime.UtcNow;
            Is_focused = isFocused;
            Is_concluded = false;
        }
        public int Task_id { get; private set; }
        public string Title { get; private set; }
        public DateTime Created_at { get; private set; }
        public bool Is_focused { get; private set; }
        public bool Is_concluded { get; private set; }

        public void UpdateSubtask(string title)
        {
            Title = title;
        }
        public void ConcludeSubtask()
        {
            Is_concluded = true;
        }
        public void MarkAsFocused()
        {
            Is_focused = true;
        }
        public void DisableFocused()
        {
            Is_focused = false;
        }
    }
}
