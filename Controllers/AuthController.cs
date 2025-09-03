using Microsoft.AspNetCore.Mvc;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseResponseModel), StatusCodes.Status500InternalServerError)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        public AuthController(IAuthService authService)
        {
            _AuthService = authService;
        }

        [HttpPost("auth")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponseModel>> auth([FromBody] LoginRequest loginRequest)
        {
            BaseResponseModel response;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                response = new BaseResponseModel(false, errors);
                return BadRequest(response);
            }
            try
            {
                string? token = await _AuthService.AuthAsync(loginRequest.Email, loginRequest.Password);
                if (token is null)
                {
                    response = new BaseResponseModel(false, "Email ou palavra-passe inválidos!");
                    return Unauthorized(response);
                }
                response = new BaseResponseModel(true, token);
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
