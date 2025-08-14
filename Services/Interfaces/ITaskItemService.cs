using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;

namespace Misoso.Api.Services.Interfaces
{
    public interface ITaskItemService
    {
        public Task<IEnumerable<TaskItemResponse>> GetTasks(int userId);
        public Task<TaskItemResponse> GetTaskById(int taskId);
        public Task<TaskItemResponse> CreateTask(CreateTaskItemRequest request);
        public Task<TaskItemResponse> UpdateTask(UpdateTaskItemRequest request);
        public Task<TaskItemResponse> ConcludeTask(TaskItemResponse taskItemResponse);
        public Task<TaskItemResponse> MarkAsFocused(TaskItemResponse taskItemResponse);
        public Task<TaskItemResponse> RemoveFocused(TaskItemResponse taskItemResponse);
        public Task DeleteTaskItem(TaskItemResponse taskItemResponse);
    }
}
