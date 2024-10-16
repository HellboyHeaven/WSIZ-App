using Backend.Data;
using Backend.Models;
using Backend.Models.Users;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Backend.Repositories;



public class RefreshTokenRepository(UniversityDbContext context, IOptions<JwtSettings> jwtSettings) : Repository<RefreshToken>(context), IRefreshTokenRepository
{
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    public async Task AddOrUpdateRefreshTokenAsync(RefreshToken refreshToken)
    {
        var existingRefreshToken = await GetByUserAsync(refreshToken.User);

        // Если токен существует, удаляем его
        if (existingRefreshToken != null)
        {
            refreshToken.Id = existingRefreshToken.Id;
            await UpdateAsync(refreshToken);
        }
        else await AddAsync(refreshToken);
    }

    public async Task DeleteByUserAsync(User user)
    {
        var entity = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.User == user);
        DeleteAsync(entity);
    }

    public async Task DeleteByUserIdAsync(string userId)
    {
        var entity = await _context.RefreshTokens.Include(r => r.User).FirstOrDefaultAsync(r => r.User.Id.ToString() == userId);
        await DeleteAsync(entity);
    }

    public async Task<RefreshToken> GetByToken(string token) 
        => await _context.RefreshTokens.AsNoTracking()
        .Include(r=> r.User)
        .FirstOrDefaultAsync(r => r.Token.Equals(token));

    public async Task<RefreshToken> GetByUserAsync(User user) 
        => await _context.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(r => r.User == user);

    public async Task SaveAsync(User user, string refreshToken)
    {
        var entity = new RefreshToken();
        entity.User = user;
        entity.ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshExpire);
    }

    
}