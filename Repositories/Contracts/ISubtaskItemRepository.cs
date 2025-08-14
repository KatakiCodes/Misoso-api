using Misoso.api.Entities;

namespace Misoso.api.Contracts
{
    public interface ISubtaskItemRepository
    {
        public Task<IEnumerable<SubtaskItem>> GetSubtaskItemsAsync();
        public Task<SubtaskItem> GetSubaskItemByIdAsync(int id);
        public Task<SubtaskItem> CreateSubtaskItemAsync(SubtaskItem subtaskItem);
        public Task<SubtaskItem> UpdateSubaskItemAsync(SubtaskItem subtaskItem);
        public Task DeleteSubtaskItemAsync(SubtaskItem subtaskItem);
    }
}
