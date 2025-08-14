using Misoso.api.Entities;

namespace Misoso.api.Contracts
{
    public interface ITaskItemRepository
    {
        public Task<IEnumerable<TaskItem>> GetTaskItemsAsync();
        public Task<TaskItem> GetTaskItemByIdAsync(int id);
        public Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem);
        public Task<TaskItem> UpdateTaskItemAsync(TaskItem taskItem);
        public Task DeleteTaskItemAsync(TaskItem taskItem);
    }
}
