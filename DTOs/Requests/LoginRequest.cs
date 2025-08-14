using System;
using System.ComponentModel.DataAnnotations;

namespace Misoso.Api.DTOs.Requests;

public record LoginRequest
{
    [Required(ErrorMessage = "O Email deve ser informado!")]
    [EmailAddress(ErrorMessage = "Informe um email válido!")]
    public string Email { get; private set; }
    [Required(ErrorMessage = "A palavra-passe deve ser informada!")]
    public string Password { get; private set; }
    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }
}
