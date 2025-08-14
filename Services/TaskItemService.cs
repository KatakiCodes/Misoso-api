using Misoso.api.Contracts;
using Misoso.api.Entities;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly ITaskItemRepository _TaskItemRepository;
        public TaskItemService(ITaskItemRepository taskItemRepository)
        {
            _TaskItemRepository = taskItemRepository;
        }

        public async Task<TaskItemResponse> ConcludeTask(TaskItemResponse taskItemResponse)
        {
            var taskItem = await _TaskItemRepository.GetTaskItemByIdAsync(taskItemResponse.Id);
            taskItem.Conclude();
            taskItem = await _TaskItemRepository.UpdateTaskItemAsync(taskItem);
            return new TaskItemResponse().ToResponseDto(taskItem);
        }

        public async Task<TaskItemResponse> CreateTask(CreateTaskItemRequest request)
        {
            var taskItem = new TaskItem(request.UserId, request.Title, request.Description, request.ToFinishAt, request.IsFocused);
            taskItem = await _TaskItemRepository.CreateTaskItemAsync(taskItem);
            return new TaskItemResponse().ToResponseDto(taskItem);
        }

        public async Task<TaskItemResponse?> GetTaskById(int taskId)
        {
            var taskItem = await _TaskItemRepository.GetTaskItemByIdAsync(taskId);
            return new TaskItemResponse().ToResponseDto(taskItem);
        }

        public async Task<IEnumerable<TaskItemResponse>> GetTasks(int userId)
        {
            var taskItems = await _TaskItemRepository.GetTaskItemsAsync();
            var filterTasks = taskItems.Where(x => x.User_Id == userId).ToList();
            var taskResponses = new List<TaskItemResponse>();

            foreach (var taskItem in filterTasks)
                taskResponses.Add(new TaskItemResponse().ToResponseDto(taskItem)!);

            return taskResponses;
        }

        public async Task<TaskItemResponse> MarkAsFocused(TaskItemResponse taskItemResponse)
        {
            var taskItem = await _TaskItemRepository.GetTaskItemByIdAsync(taskItemResponse.Id);
            taskItem.MasrkAsFocused();
            taskItem = await _TaskItemRepository.UpdateTaskItemAsync(taskItem);
            return new TaskItemResponse().ToResponseDto(taskItem)!;
        }

        public async Task<TaskItemResponse> RemoveFocused(TaskItemResponse taskItemResponse)
        {
            var taskItem = await _TaskItemRepository.GetTaskItemByIdAsync(taskItemResponse.Id);
            taskItem.DisableFocused();
            taskItem = await _TaskItemRepository.UpdateTaskItemAsync(taskItem);
            return new TaskItemResponse().ToResponseDto(taskItem)!;
        }

        public async Task<TaskItemResponse?> UpdateTask(UpdateTaskItemRequest request)
        {
            var taskItem = await _TaskItemRepository.GetTaskItemByIdAsync(request.Id);
            taskItem.UpdateTask(request.Title, request.Description);
            taskItem = await _TaskItemRepository.UpdateTaskItemAsync(taskItem);
            return new TaskItemResponse().ToResponseDto(taskItem);
        }
        public async Task DeleteTaskItem(TaskItemResponse taskItemResponse)
        {
            var taskItem = await _TaskItemRepository.GetTaskItemByIdAsync(taskItemResponse.Id);
            await _TaskItemRepository.DeleteTaskItemAsync(taskItem);
        }
    }
}
