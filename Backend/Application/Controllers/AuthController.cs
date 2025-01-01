using Backend.Application.Services;
using Backend.Core.DTOs.Auth;
using Backend.Core.Exceptions;
using Backend.Core.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(AuthService authService) : ControllerBase
{
    private readonly AuthService _authService = authService;

    [HttpPost("sign-up/teacher")]
    public async Task<ActionResult<string>> Register(TeacherRegisterDto registerDto)
    {
        try
        {
            await _authService.SignUpAsync(registerDto);
            return Ok("success");
        }
        catch (AlreadyExistsException e)
        {
            return ValidationProblem(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("sign-up/student")]
    public async Task<ActionResult<string>> Register(StudentRegisterDto registerDto)
    {
        try
        {
            await _authService.SignUpAsync(registerDto);
            return Ok("success");
        }
        catch (AlreadyExistsException e)
        {
            return ValidationProblem(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("verify")]
    [Authorize]
    public ActionResult<User> Verify(LoginDto loginDto)
    {
        return Ok(true);
    }


    [HttpPost("sign-in")]
    public async Task<ActionResult<User>> LogIn(LoginDto loginDto)
    {
        var response = await _authService.SignInAsync(loginDto);
        return Ok(response);
    }

    [HttpPost("sign-out")]
    [Authorize]
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