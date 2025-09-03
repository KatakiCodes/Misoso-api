using System;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _TokenService;
    private readonly IUserService _IUserService;
    public AuthService(IUserService userService, ITokenService tokenService)
    {
        _TokenService = tokenService;
        _IUserService = userService;
    }
    public async Task<string?> AuthAsync(string email, string password)
    {
        var userResponse = await _IUserService.Login(email, password);
        if (userResponse is null)
            return null;
        var token = _TokenService.GenerateToken(userResponse);
        return token;
    }

    public Task<string> GoogleAuthAsync(string tokenId)
    {
        throw new NotImplementedException();
    }
}
