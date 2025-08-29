using Microsoft.EntityFrameworkCore;
using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.Data;
using Misoso.Api.Repositories;
using System.Data;

namespace Misoso.api.Repositories
{
    public class TaskITemRepository : BaseRepository, ITaskItemRepository
    {
        public TaskITemRepository(DataContext dataContext) : base(dataContext)
        { }
        public async Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem)
        {
            await _Context.Tasks.AddAsync(taskItem);
            await _Context.SaveChangesAsync();
            return taskItem;
        }

        public async Task DeleteTaskItemAsync(TaskItem taskItem)
        {
            _Context.Tasks.Remove(taskItem);
            await _Context.SaveChangesAsync();
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int id)
        {
            return await _Context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
        {
            var users = await _Context.Tasks.AsNoTracking().ToListAsync();
            return users.AsEnumerable();
        }

        public async Task<TaskItem> UpdateTaskItemAsync(TaskItem taskItem)
        {
            _Context.Entry<TaskItem>(taskItem).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return taskItem;
        }
    }
}
