using System;
using Misoso.Api.Services.Interfaces;
using Google.Apis.Auth;
using Misoso.Api.DTOs.Requests;
using Misoso.Api.DTOs.Responses;

namespace Misoso.Api.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _TokenService;
    private readonly IUserService _IUserService;
    private readonly IConfiguration _Configuration;
    public AuthService(IUserService userService, ITokenService tokenService, IConfiguration configuration)
    {
        _TokenService = tokenService;
        _IUserService = userService;
        _Configuration = configuration;
    }
    public async Task<AuthResponse?> AuthAsync(string email, string password)
    {
        var userResponse = await _IUserService.Login(email, password);
        if (userResponse is null)
            return null;
        var token = _TokenService.GenerateToken(userResponse);
        return new AuthResponse(userResponse.Email,userResponse.UserName, token);
    }

    public async Task<string?> GoogleAuthAsync(string tokenId)
    {
        var payloads = await GoogleJsonWebSignature.ValidateAsync(tokenId, new GoogleJsonWebSignature.ValidationSettings
        {
            Audience = [_Configuration.GetSection("Google:Authentication:ClientId").Value]
        });
        var user = await _IUserService.GetUserByExternalIdAsync(payloads.Subject);

        user ??= await _IUserService.CreateUserAsync(new(payloads.Email, payloads.Name, "", payloads.Subject));
        return _TokenService.GenerateToken(user);
    }
}
