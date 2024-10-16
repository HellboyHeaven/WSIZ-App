using Backend.Data;
using Backend.Models.Users;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;
public class UserRepository(UniversityDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User> GetUserByLoginAsync(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
    }

}