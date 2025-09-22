using System;
using Misoso.api.Entities;

namespace Misoso.Api.DTOs.Responses;

public record AuthResponse
{
    public AuthResponse(string email, string username, string token)
    {
        Email = email;
        Username = username;
        Token = token;
    }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Token { get; private set; }
}
