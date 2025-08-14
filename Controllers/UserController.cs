using Microsoft.AspNetCore.Mvc;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ProducesResponseType(typeof(BaseResponseModel),StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController([FromServices] IUserService userService)
        {
            _UserService = userService;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponseModel>> GetUser([FromRoute] int id)
        {
            try
            {
                BaseResponseModel response;
                var userResponse = await _UserService.GetUserAsync(id);
                if (userResponse is null)
                {
                    response = new BaseResponseModel(false,"Utilizador não localizado!");
                    return NotFound(response);
                }
                response = new BaseResponseModel(true,userResponse);
                return Ok(response);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CreateUserRequest), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponseModel>> CreateUser([FromBody] CreateUserRequest request)
        {
            BaseResponseModel response;

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(x=>x.Errors).Select(v=>v.ErrorMessage).ToList<string>();
                response = new BaseResponseModel(false,errors);
                return BadRequest(ModelState);
            }
            try
            {
                var userResponse = await _UserService.CreateUserAsync(request);
                response = new BaseResponseModel(true,userResponse);
                return Created("user",response);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro inesperado!");
            }
        }
    }
}
