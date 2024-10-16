using Backend.Data;
using Backend.Models.Users;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class StudentRepository(UniversityDbContext context) : UserRepository(context), IStudentRepository
{
        public async Task<IEnumerable<Student>> GetStudentsByGroupIdAsync(Guid groupId)
        {
            return await _context.Users.OfType<Student>().Where(s => s.Groups.Any(g => g.Id == groupId)).ToListAsync();
        }
    }