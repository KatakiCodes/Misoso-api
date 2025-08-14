using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Misoso.Api.DTOs.Responses;
using Misoso.Api.Services.Interfaces;

namespace Misoso.Api.Services;

public class TokenService : ITokenService
{
    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
        _jwtSecret = _configuration.GetSection("JwtOptions:secretKey").Value;
    }
    private readonly IConfiguration _configuration;
    private readonly string _jwtSecret;
    private readonly int _jwtExpireHours = 1;

    public string GenerateToken(UserResponse userResponse)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userResponse.Id.ToString()),
            new Claim(ClaimTypes.Email, userResponse.Email),
            new Claim(ClaimTypes.Name, userResponse.UserName)
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(_jwtExpireHours),
            SigningCredentials = creds,
            Issuer = _configuration.GetSection("JwtOptions:issuer").Value,
            Audience = _configuration.GetSection("JwtOptions:audience").Value
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
