using Microsoft.EntityFrameworkCore;
using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.Data;
using Misoso.Api.Repositories;
using System.Data;

namespace Misoso.api.Repositories
{
    public class SubtaskItemRepository : BaseRepository, ISubtaskItemRepository
    {
        public SubtaskItemRepository(DataContext dataContext) : base(dataContext)
        {}
        public async Task<SubtaskItem> CreateSubtaskItemAsync(SubtaskItem subtaskItem)
        {
            await _Context.SubTasks.AddAsync(subtaskItem);
            await _Context.SaveChangesAsync();
            return subtaskItem;
        }

        public async Task DeleteSubtaskItemAsync(SubtaskItem subtaskItem)
        {
            _Context.SubTasks.Remove(subtaskItem);
            await _Context.SaveChangesAsync();
;        }

        public async Task<SubtaskItem?> GetSubaskItemByIdAsync(int id)
        {
            return await _Context.SubTasks.FindAsync(id);
        }

        public async Task<IEnumerable<SubtaskItem>> GetSubtaskItemsAsync()
        {
            var subtasks = await _Context.SubTasks.AsNoTracking().ToListAsync();
            return subtasks.AsEnumerable();
        }

        public async Task<SubtaskItem> UpdateSubaskItemAsync(SubtaskItem subtaskItem)
        {
            _Context.Entry<SubtaskItem>(subtaskItem).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
            return subtaskItem;
        }
    }
}
