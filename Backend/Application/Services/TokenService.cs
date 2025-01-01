using Backend.Core.Attributes;
using Backend.Core.Models;
using Backend.Core.Models.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Application.Services;

[Service]
public class TokenService(IOptions<JwtSettings> jwtSettings)
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public string GenerateToken(User user)
    {
        var claims = new[]
        {

            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim("role", user.Role())  // Добавляем роль в токен
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Expire),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public RefreshToken GenerateRefreshToken(User user)
    {
        string value;
        var randomBytes = new byte[64];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomBytes);
            value = Convert.ToBase64String(randomBytes);
        }

        var refreshToken = new RefreshToken();
        refreshToken.User = user;
        refreshToken.Token = value;
        refreshToken.ExpiryDate = DateTime.UtcNow.AddMinutes(_jwtSettings.RefreshExpire);

        return refreshToken;
    }
}