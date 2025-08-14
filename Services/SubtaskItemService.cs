using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Services
{
    public class SubtaskItemService : ISubtaskItemService
    {
        private ISubtaskItemRepository _Repository { get; set; }
        public SubtaskItemService(ISubtaskItemRepository subtaskItemRepository)
        {
            _Repository = subtaskItemRepository;
        }
        public async Task<SubtaskItemResponse> ConcludeSubTask(SubtaskItemResponse subtaskItemResponse)
        {
            var subtaskItem = await _Repository.GetSubaskItemByIdAsync(subtaskItemResponse.Id);
            subtaskItem.ConcludeSubtask();
            subtaskItem = await _Repository.UpdateSubaskItemAsync(subtaskItem);
            return new SubtaskItemResponse().ToResponseDto(subtaskItem);
        }

        public async Task<SubtaskItemResponse> CreateSubTask(CreateSubtaskItemRequest request)
        {
            var subtaskItem = new SubtaskItem(request.TaskItemId, request.Title, request.IsFocused);
            subtaskItem = await _Repository.CreateSubtaskItemAsync(subtaskItem);
            return new SubtaskItemResponse().ToResponseDto(subtaskItem);
        }

        public async Task DeleteSubTask(SubtaskItemResponse subtaskItemResponse)
        {
            var subtaskItem = await _Repository.GetSubaskItemByIdAsync(subtaskItemResponse.Id);
            await _Repository.DeleteSubtaskItemAsync(subtaskItem);
        }

        public async Task<SubtaskItemResponse?> GetSubTaskById(int subtaskId)
        {
            var subtaskItem = await _Repository.GetSubaskItemByIdAsync(subtaskId);
            return new SubtaskItemResponse().ToResponseDto(subtaskItem);
        }

        public async Task<IEnumerable<SubtaskItemResponse>> GetSubtasks(int taskId)
        {
            var subtaskItemResponses = new List<SubtaskItemResponse>();
            var subtaskList = await _Repository.GetSubtaskItemsAsync();
            foreach (var subtaskItem in subtaskList.Where(item=>item.Task_Id == taskId))
                subtaskItemResponses.Add(new SubtaskItemResponse().ToResponseDto(subtaskItem));
            return subtaskItemResponses.AsEnumerable();
        }

        public async Task<SubtaskItemResponse> MarkAsFocused(SubtaskItemResponse subtaskItemResponse)
        {
            var subtaskItem = await _Repository.GetSubaskItemByIdAsync(subtaskItemResponse.Id);
            subtaskItem.MarkAsFocused();
            subtaskItem = await _Repository.UpdateSubaskItemAsync(subtaskItem);
            return new SubtaskItemResponse().ToResponseDto(subtaskItem);
        }

        public async Task<SubtaskItemResponse> RemoveFocused(SubtaskItemResponse subtaskItemResponse)
        {
            var subtaskItem = await _Repository.GetSubaskItemByIdAsync(subtaskItemResponse.Id);
            subtaskItem.DisableFocused();
            subtaskItem = await _Repository.UpdateSubaskItemAsync(subtaskItem);
            return new SubtaskItemResponse().ToResponseDto(subtaskItem);
        }

        public async Task<SubtaskItemResponse> UpdateSubTask(UpdateSubtaskItemRequest request)
        {
            var subtaskItem = await _Repository.GetSubaskItemByIdAsync(request.Id);
            subtaskItem.UpdateSubtask(request.Title);
            subtaskItem = await _Repository.UpdateSubaskItemAsync(subtaskItem);
            return new SubtaskItemResponse().ToResponseDto(subtaskItem);
        }
    }
}
