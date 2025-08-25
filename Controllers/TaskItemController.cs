using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseModel),StatusCodes.Status500InternalServerError)]
    [Authorize]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _TaskItemService;
        public TaskItemController(ITaskItemService taskItemService)
        {
            _TaskItemService = taskItemService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponseModel>> GetTasks()
        {
            BaseResponseModel response;
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    response = new BaseResponseModel(false,"Utilizador não autenticado!");
                    return Unauthorized(response);
                }

                var taskItemResponses = await _TaskItemService.GetTasks(int.Parse(userId));
                response = new BaseResponseModel(true,taskItemResponses);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false,"Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> GetTaskById([FromRoute] int id)
        {
            BaseResponseModel response;
            try
            {
                var taskItemResponse = await _TaskItemService.GetTaskById(id);
                if (taskItemResponse is null)
                {
                    response = new BaseResponseModel(false,"Tarefa não localizada!");
                    return NotFound(response);
                }
                response = new BaseResponseModel(true,taskItemResponse);
                return Ok(response);
            }
            catch (Exception ex)
            {
                response = new BaseResponseModel(false,"Erro inesperado! " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseModel>> CreateTask(
            [FromServices] IUserService userService,
            [FromBody] CreateTaskItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(v => v.ErrorMessage).ToList();
                var response = new BaseResponseModel(false,errors);
                return BadRequest(response);
            }

            try
            {
                var user = await userService.GetUserAsync(request.UserId);
                if (user is null)
                    return BadRequest(new BaseResponseModel(false,"Utilizador invlálido!"));

                var taskItemResponse = await _TaskItemService.CreateTask(request);
                var response = new BaseResponseModel(true,taskItemResponse);
                return Created("task", response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado! "+ex.Message);
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseModel>> UpdateTask(
            [FromBody] UpdateTaskItemRequest request
            )
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x => x.Errors).Select(v => v.ErrorMessage).ToList();
                var response = new BaseResponseModel(false,errors);
                return BadRequest(response);
            }

            try
            {
                var taskItemResponse = await _TaskItemService.GetTaskById(request.Id);
                if (taskItemResponse is null)
                {
                    var response = new BaseResponseModel(false,"Tarefa não localizada!");
                    return NotFound(response);
                }
                taskItemResponse = await _TaskItemService.UpdateTask(request);
                var responseModel = new BaseResponseModel(true,taskItemResponse);
                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!" + ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteTask([FromRoute] int id)
        {
            try
            {
                var taskItemResponse = await _TaskItemService.GetTaskById(id);
                if (taskItemResponse is null)
                {
                    var response = new BaseResponseModel(false,"Tarefa não localizada!");
                    return NotFound(response);
                }
                await _TaskItemService.DeleteTaskItem(taskItemResponse);
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!");
            }
        }

        [HttpPut("complete/{taskid:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> CompleteTask(int taskid)
        {
            BaseResponseModel response;
            try
            {
                var taskItemResponses = await _TaskItemService.GetTaskById(taskid);
                if(taskItemResponses is null)
                {
                    response = new BaseResponseModel(false,"Tarefa não localizada!");
                    return NotFound(response);
                }
                taskItemResponses = await _TaskItemService.ConcludeTask(taskItemResponses);
                response = new BaseResponseModel(true,taskItemResponses);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false,"Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }

        [HttpPut("markasfocused/{taskid:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> MarkAsFocused(int taskid)
        {
            BaseResponseModel response;
            try
            {
                var taskItemResponses = await _TaskItemService.GetTaskById(taskid);
                if(taskItemResponses is null)
                {
                    response = new BaseResponseModel(false,"Tarefa não localizada!");
                    return NotFound(response);
                }
                taskItemResponses = await _TaskItemService.MarkAsFocused(taskItemResponses);
                response = new BaseResponseModel(true,taskItemResponses);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false,"Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    
        [HttpPut("unmarkasfocused/{taskid:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> UnMarkAsFocused(int taskid)
        {
            BaseResponseModel response;
            try
            {
                var taskItemResponses = await _TaskItemService.GetTaskById(taskid);
                if(taskItemResponses is null)
                {
                    response = new BaseResponseModel(false,"Tarefa não localizada!");
                    return NotFound(response);
                }
                taskItemResponses = await _TaskItemService.RemoveFocused(taskItemResponses);
                response = new BaseResponseModel(true,taskItemResponses);
                return Ok(response);
            }
            catch (Exception)
            {
                response = new BaseResponseModel(false,"Erro inesperado!");
                return StatusCode(StatusCodes.Status500InternalServerError, response);
            }
        }
    }
}
