using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Controllers
{
    [Route("api/subtasks")]
    [ApiController]
    [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Authorize]
    public class SubtaskItemController : ControllerBase
    {
        private readonly ISubtaskItemService _subtaskItemService;
        public SubtaskItemController(ISubtaskItemService subtaskItemService)
        {
            _subtaskItemService = subtaskItemService;
        }

        [HttpGet("{taskId:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> GetSubtasks([FromRoute] int taskId)
        {
            BaseResponseModel response;
            try
            {
                var subtasks = await _subtaskItemService.GetSubtasks(taskId);
                response = new BaseResponseModel(true, subtasks);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false, "Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseModel>> CreateSubtask(
            [FromServices] ITaskItemService taskItemService,
            [FromBody] CreateSubtaskItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(v => v.ErrorMessage).ToList();
                var response = new BaseResponseModel(false, errors);
                return BadRequest(response);
            }

            try
            {
                var task = await taskItemService.GetTaskById(request.TaskItemId);
                if (task is null)
                    return BadRequest(new BaseResponseModel(false, "Tarefa não localizada!"));

                var subtaskResponse = await _subtaskItemService.CreateSubTask(request);
                var response = new BaseResponseModel(true, subtaskResponse);
                return Created("subtask", response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseModel>> UpdateSubtask(
            [FromBody] UpdateSubtaskItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(v => v.ErrorMessage).ToList();
                var response = new BaseResponseModel(false, errors);
                return BadRequest(response);
            }

            try
            {
                var subtask = await _subtaskItemService.GetSubTaskById(request.Id);
                if (subtask is null)
                {
                    var response = new BaseResponseModel(false, "Etápa não localizada!");
                    return NotFound(response);
                }
                var subtaskResponse = await _subtaskItemService.UpdateSubTask(request);
                var responseModel = new BaseResponseModel(true, subtaskResponse);
                return Ok(responseModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteSubtask([FromRoute] int id)
        {
            try
            {
                var subtaskResponse = await _subtaskItemService.GetSubTaskById(id);
                if (subtaskResponse is null)
                {
                    var response = new BaseResponseModel(false, "Etápa não localizada!");
                    return NotFound(response);
                }
                await _subtaskItemService.DeleteSubTask(subtaskResponse);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!");
            }
        }

        [HttpPut("complete/{id:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> CompleteSubtask([FromRoute] int id)
        {
            BaseResponseModel response;
            try
            {
                var subtask = await _subtaskItemService.GetSubTaskById(id);
                if (subtask is null)
                {
                    response = new BaseResponseModel(false, "Etápa não localizada!");
                    return NotFound(response);
                }
                var completedSubtask = await _subtaskItemService.ConcludeSubTask(subtask);
                response = new BaseResponseModel(true, completedSubtask);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false, "Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("MarkAsFocused/{id:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> UncompleteSubtask([FromRoute] int id)
        {
            BaseResponseModel response;
            try
            {
                var subtask = await _subtaskItemService.GetSubTaskById(id);
                if (subtask is null)
                {
                    response = new BaseResponseModel(false, "Etápa não localizada!");
                    return NotFound(response);
                }
                var uncompletedSubtask = await _subtaskItemService.MarkAsFocused(subtask);
                response = new BaseResponseModel(true, uncompletedSubtask);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false, "Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("UnMarkAsFocused/{id:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> UnMarkAsFocused([FromRoute] int id)
        {
            BaseResponseModel response;
            try
            {
                var subtask = await _subtaskItemService.GetSubTaskById(id);
                if (subtask is null)
                {
                    response = new BaseResponseModel(false, "Etápa não localizada!");
                    return NotFound(response);
                }
                var toggledSubtask = await _subtaskItemService.RemoveFocused(subtask);
                response = new BaseResponseModel(true, toggledSubtask);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false, "Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

    }
}
