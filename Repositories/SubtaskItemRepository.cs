using Dapper;
using Dapper.Contrib.Extensions;
using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.Repositories;
using System.Data;

namespace Misoso.api.Repositories
{
    public class SubtaskItemRepository : BaseRepository, ISubtaskItemRepository
    {
        public SubtaskItemRepository(IConfiguration configuration) : base(configuration)
        {}
        public async Task<SubtaskItem> CreateSubtaskItemAsync(SubtaskItem subtaskItem)
        {
            string sql = "INSERT INTO Subtasks OUTPUT INSERTED.ID VALUES (@TASK_ID, @TITLE,@CREATED_AT,@IS_CONCLUDED,@IS_FOCUSED);";
            var createdId = await _Connection.ExecuteScalarAsync<int>(sql,
                new
                {
                    subtaskItem.Task_Id,
                    subtaskItem.Title,
                    subtaskItem.Created_At,
                    subtaskItem.Is_Concluded,
                    subtaskItem.Is_Focused,
                }
                );
            var subtaskResult = await _Connection.GetAsync<SubtaskItem>(createdId);
            return subtaskResult;
        }

        public async Task DeleteSubtaskItemAsync(SubtaskItem subtaskItem)
        {
            await _Connection.DeleteAsync(subtaskItem);
        }

        public async Task<SubtaskItem?> GetSubaskItemByIdAsync(int id)
        {
            return await _Connection.GetAsync<SubtaskItem>(id);
        }

        public async Task<IEnumerable<SubtaskItem>> GetSubtaskItemsAsync()
        {
            return await _Connection.GetAllAsync<SubtaskItem>(); 
        }

        public async Task<SubtaskItem> UpdateSubaskItemAsync(SubtaskItem subtaskItem)
        {
            await _Connection.UpdateAsync(subtaskItem);
            return subtaskItem;
        }
    }
}
