using Backend.Core.Attributes;
using Backend.Core.Models.Users;
using Backend.Data;
using Backend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories;


public class UserRepository <T> (UniversityDbContext context) : Repository<T>(context), IUserRepository<T> where T : User
{
    public async Task<T?> GetUserByLoginAsync(string login)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Login == login) as T;
    }

}