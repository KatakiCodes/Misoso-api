using System;
using Misoso.Api.DTOs.Responses;

namespace Misoso.Api.Services.Interfaces;

public interface IAuthService
{
    public Task<AuthResponse> AuthAsync(string email, string password);
    public Task<string> GoogleAuthAsync(string tokenId);
}
