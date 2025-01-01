using Backend.Core.Attributes;
using Backend.Core.Models.Users;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

[Repository]
public class StudentRepository(UniversityDbContext context) : UserRepository<Student>(context), IStudentRepository
{
    public override async Task<Student?> GetByIdAsync(Guid id)
        => await _context.Users.OfType<Student>()
        .Include(s => s.Groups)
        .Include(s => s.Course)
        .FirstOrDefaultAsync(o=> o.Id == id);

    public async Task<IEnumerable<Student>> GetStudentsByGroupIdAsync(Guid groupId)
        => await _context.Users.OfType<Student>().Where(s => s.Groups.Any(g => g.Id == groupId)).ToListAsync();
}