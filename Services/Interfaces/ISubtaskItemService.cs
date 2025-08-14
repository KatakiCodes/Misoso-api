using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;

namespace Misoso.Api.Services.Interfaces
{
    public interface ISubtaskItemService
    {
        public Task<IEnumerable<SubtaskItemResponse>> GetSubtasks(int taskId);
        public Task<SubtaskItemResponse> GetSubTaskById(int subtaskId);
        public Task<SubtaskItemResponse> CreateSubTask(CreateSubtaskItemRequest request);
        public Task<SubtaskItemResponse> UpdateSubTask(UpdateSubtaskItemRequest request);
        public Task<SubtaskItemResponse> ConcludeSubTask(SubtaskItemResponse subtaskItemResponse);
        public Task<SubtaskItemResponse> MarkAsFocused(SubtaskItemResponse subtaskItemResponse);
        public Task<SubtaskItemResponse> RemoveFocused(SubtaskItemResponse subtaskItemResponse);
        public Task DeleteSubTask(SubtaskItemResponse subtaskItemResponse);
    }
}
