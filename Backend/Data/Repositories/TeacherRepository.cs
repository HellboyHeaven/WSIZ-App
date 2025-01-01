using Backend.Core.Attributes;
using Backend.Core.Models.Users;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


[Repository]
public class TeacherRepository(UniversityDbContext context) : UserRepository<Teacher>(context), ITeacherRepository
{

    public async Task<IEnumerable<Teacher>> GetTeachersBySubjectIdAsync(Guid subjectId)
    {
        return await _context.Users.OfType<Teacher>().Where(t => t.Subjects.Any(s => s.Id == subjectId)).ToListAsync();
    }
}