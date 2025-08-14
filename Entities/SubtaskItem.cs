using System.ComponentModel.DataAnnotations.Schema;

namespace Misoso.api.Entities
{
    [Table("SUBTASKS")]
    public class SubtaskItem : BaseEntity
    {
        public SubtaskItem()
        {}
        public SubtaskItem(int taskId, string title, bool isFocused)
        {
            Task_Id = taskId;
            Title = title;
            Created_At = DateTime.UtcNow;
            Is_Focused = isFocused;
            Is_Concluded = false;
        }
        public SubtaskItem(int id, int taskId, string title, DateTime createdAt, bool isFocused, bool isConcluded) : base(id)
        {
            Task_Id = taskId;
            Title = title;
            Created_At = createdAt;
            Is_Focused = isFocused;
            Is_Concluded = isConcluded;
        }
        public int Task_Id { get; private set; }
        public string Title { get; private set; }
        public DateTime Created_At { get; private set; }
        public bool Is_Focused { get; private set; }
        public bool Is_Concluded { get; private set; }

        public void UpdateSubtask(string title)
        {
            Title = title;
        }
        public void ConcludeSubtask()
        {
            Is_Concluded = true;
        }
        public void MarkAsFocused()
        {
            Is_Focused = true;
        }
        public void DisableFocused()
        {
            Is_Focused = false;
        }
    }
}
