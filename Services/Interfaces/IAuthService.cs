using System;

namespace Misoso.Api.Services.Interfaces;

public interface IAuthService
{
    public Task<string> AuthAsync(string email, string password);
    public Task<string> GoogleAuthAsync(string tokenId);
}
