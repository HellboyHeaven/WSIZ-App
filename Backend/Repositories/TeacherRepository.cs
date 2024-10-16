using Backend.Data;
using Backend.Models.Users;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class TeacherRepository(UniversityDbContext context) : UserRepository(context), ITeacherRepository
{

    public async Task<IEnumerable<Teacher>> GetTeachersBySubjectIdAsync(Guid subjectId)
    {
        return await _context.Users.OfType<Teacher>().Where(t => t.Subjects.Any(s => s.Id == subjectId)).ToListAsync();
    }
}