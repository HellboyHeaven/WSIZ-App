using Backend.Data;
using Backend.DTOs;
using Backend.Models.Users;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Backend.Services;

public class AuthService(UniversityDbContext context, TokenService tokenService, IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
{
    private readonly UniversityDbContext _context = context;
    private readonly TokenService _tokenService = tokenService;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;


    public async Task SignUpAsync(RegisterDto registerDto)
    {
        // Хэшируем пароль с помощью BCrypt
       

        User user = null;

        switch (registerDto.Role)
        {
            case "Student":
                user = registerStudent(registerDto);
                break;
            case "Teacher":
                user = registerTeacher(registerDto);
                break;
        }


        await _userRepository.AddAsync(user);
    }

    public async Task<AuthResponse> SignInAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetUserByLoginAsync(loginDto.Login);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            throw new Exception("Invalid credentials");
        }

        // Генерация JWT токена
        var jwtToken = _tokenService.GenerateToken(user);

        // Генерация Refresh токена
        var refreshToken = _tokenService.GenerateRefreshToken(user);
        Trace.WriteLine("SAVE REFRESH TOKEN");
        await _refreshTokenRepository.AddOrUpdateRefreshTokenAsync(refreshToken);



        return new AuthResponse
        {
            JwtToken = jwtToken,
            RefreshToken = refreshToken.Token
        };
    }

    
    public async Task LogOutAsync(string userId)
    {
        await _refreshTokenRepository.DeleteByUserIdAsync(userId);
    }

    public async Task<AuthResponse> RefreshTokenAsync( RefreshTokenDto refreshTokenDto)
    {
        var refreshToken = await _refreshTokenRepository.GetByToken(refreshTokenDto.RefreshToken);
        if (refreshToken == null || refreshToken.Token != refreshTokenDto.RefreshToken)
            throw new UnauthorizedAccessException();

        var user = refreshToken.User;

        var newRefreshToken = _tokenService.GenerateRefreshToken(user);
        var accessToken = _tokenService.GenerateToken(user);




        await _refreshTokenRepository.AddOrUpdateRefreshTokenAsync(newRefreshToken);

        return new AuthResponse
        {
            JwtToken = accessToken,
            RefreshToken = newRefreshToken.Token
        };
    }

    private User registerUser(RegisterDto registerDto, User user)
    {
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
        user.Login = registerDto.Login;
        user.PasswordHash = hashedPassword;
        user.Email = registerDto.Email;
        user.FirstName = registerDto.FirstName;
        user.LastName = registerDto.LastName;
        user.BirthDay = registerDto.BirthDay;
        return user;
    }

    private User registerStudent(RegisterDto registerDto)
    {
        var user = new Student();
        return registerUser(registerDto, user);
    }

    private User registerTeacher(RegisterDto registerDto)
    {
        var user = new Teacher();
        return registerUser(registerDto, user);
    }
}
