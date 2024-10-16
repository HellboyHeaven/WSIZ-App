using Backend.Models.Users;

namespace Backend.Repositories.Interfaces;


public interface IRefreshTokenRepository : IRepository<RefreshToken>
{
    Task SaveAsync(User user, string refreshToken);

    // Получение refresh токена для пользователя
    Task<RefreshToken> GetByUserAsync(User user);

    // Удаление refresh токена
    Task DeleteByUserAsync(User user);
    Task DeleteByUserIdAsync(string userId);

    Task<RefreshToken> GetByToken(string token);

    Task AddOrUpdateRefreshTokenAsync(RefreshToken token);
}