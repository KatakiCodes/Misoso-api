using System;
using Misoso.Api.DTOs.Responses;

namespace Misoso.Api.Services.Interfaces;

public interface ITokenService
{
    public string GenerateToken(UserResponse userResponse);
}
