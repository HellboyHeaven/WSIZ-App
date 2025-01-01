using Backend.Core.Models.Users;

namespace Backend.Data.Repositories.Interfaces;

public interface IUserRepository<T> : IRepository<T> where T : User
{
    Task<T?> GetUserByLoginAsync(string login);

}