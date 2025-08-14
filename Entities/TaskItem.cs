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
            User_Id = userId;
            Title = title;
            Description = description;
            Created_At = DateTime.UtcNow;
            To_Finish_At = toFinishAt;
            Is_Focused = isFocused;
        }
        public TaskItem(int id, int userId, string title, string description, DateTime createdAt, DateTime? toFinishAt, DateTime? finishedAt, bool isFocused) : base(id)
        {
            User_Id = userId;
            Title = title;
            Description = description;
            Created_At = createdAt;
            To_Finish_At = toFinishAt;
            Finished_At = finishedAt;
            Is_Focused = isFocused;
        }

        public int User_Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public DateTime Created_At { get; private set; }
        public DateTime? To_Finish_At { get; private set; }
        public DateTime? Finished_At { get; private set; }
        public bool Is_Focused { get; private set; }

        public void UpdateTask(string title, string description)
        {
            Title = title;
            Description = description;
        }
        public void MasrkAsFocused()
        {
            Is_Focused = true;
        }
        public void DisableFocused()
        {
            Is_Focused = false;
        }
        public void Conclude()
        {
            Finished_At = DateTime.Now;
        }
    }
}
