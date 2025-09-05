using System.ComponentModel.DataAnnotations;

namespace Misoso.Api.DTOs.Requests
{
    public record CreateUserRequest
    {
        [Required(ErrorMessage = "O email do utilizador deve ser informado!")]
        [EmailAddress(ErrorMessage = "Informe um email válido!")]
        public string Email { get; private set; }
        [Required(ErrorMessage = "O nome do utilizador deve ser informado!")]
        public string UserName { get; private set; }
        [Required(ErrorMessage = "A palavra-passe do utilizador deve ser informada!")]
        public string? Password { get; private set; }
        public string? ExternalId { get; private set; }

        public CreateUserRequest(string email, string userName, string? password = default, string? externalId = default)
        {
            Email = email;
            UserName = userName;
            Password = password;
            ExternalId = externalId;
        }
    }
}
