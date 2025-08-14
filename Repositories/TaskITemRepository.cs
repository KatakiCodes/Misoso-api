using Dapper;
using Dapper.Contrib.Extensions;
using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.Repositories;
using System.Data;

namespace Misoso.api.Repositories
{
    public class TaskITemRepository : BaseRepository, ITaskItemRepository
    {
        public TaskITemRepository(IConfiguration configuration) : base(configuration)
        { }
        public async Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem)
        {
            string sql = "INSERT INTO Tasks OUTPUT INSERTED.ID VALUES (@USER_ID, @TITLE, @DESCRIPTION,@CREATED_AT,@TO_FINISH_AT,@FINISHED_AT,@IS_FOCUSED);";
            var createdId = await _Connection.ExecuteScalarAsync<int>(sql,
                new
                {
                    taskItem.User_Id,
                    taskItem.Title,
                    taskItem.Description,
                    taskItem.Created_At,
                    taskItem.To_Finish_At,
                    taskItem.Finished_At,
                    taskItem.Is_Focused,
                }
            );
            return await GetTaskItemByIdAsync(createdId);
        }

        public async Task DeleteTaskItemAsync(TaskItem taskItem)
        {
            await _Connection.DeleteAsync(taskItem);
        }

        public async Task<TaskItem?> GetTaskItemByIdAsync(int id)
        {
            return await _Connection.GetAsync<TaskItem>(id);
        }

        public async Task<IEnumerable<TaskItem>> GetTaskItemsAsync()
        {
            return await _Connection.GetAllAsync<TaskItem>();
        }

        public async Task<TaskItem> UpdateTaskItemAsync(TaskItem taskItem)
        {
            await _Connection.UpdateAsync(taskItem);
            return taskItem;
        }
    }
}
