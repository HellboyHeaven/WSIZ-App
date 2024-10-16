using Backend.Models.Users;

namespace Backend.Repositories.Interfaces;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetUserByLoginAsync(string login);

}