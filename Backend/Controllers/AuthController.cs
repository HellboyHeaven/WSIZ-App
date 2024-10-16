using Backend.DTOs;
using Backend.Models.Users;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(AuthService authService) : ControllerBase
{
    private readonly AuthService _authService = authService;

    [HttpPost("sing-up")]
    public async Task<ActionResult<string>> Register(RegisterDto registerDto)
    {
        await _authService.SignUpAsync(registerDto);
        return Ok("success");
    }

    [HttpPost("sing-in")]
    public async Task<ActionResult<User>> LogIn(LoginDto loginDto)
    {
        var response = await _authService.SignInAsync(loginDto);
        return Ok(response);
    }

    [HttpPost("sing-out")]
    public async Task<ActionResult<User>> LogOut(LoginDto loginDto)
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var sub = jwtToken.Subject;

        await _authService.LogOutAsync(sub);
        return Ok("success");
    }

    [HttpPost("refresh")]
    public async Task<ActionResult<User>> RefreshToken(RefreshTokenDto refreshTokenDto)
    {
        try
        {
            var response = await _authService.RefreshTokenAsync(refreshTokenDto);
            return Ok(response);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);
        }
    }


}