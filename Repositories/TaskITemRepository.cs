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
            string sql = @"INSERT INTO Tasks 
                (user_id, title, description, created_at, to_finish_at, finished_at, is_focused) 
                VALUES 
                (@User_Id, @Title, @Description, @Created_At, @To_Finish_At, @Finished_At, @Is_Focused) 
                RETURNING id;";
            var createdId = await _Connection.ExecuteScalarAsync<int>(sql,
                new
                {
                    taskItem.user_id,
                    taskItem.title,
                    taskItem.description,
                    taskItem.created_at,
                    taskItem.to_finish_at,
                    taskItem.finished_at,
                    taskItem.is_focused,
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
