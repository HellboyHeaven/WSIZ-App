using Backend.Core.Attributes;
using Backend.Core.Models;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

[Repository]
public class CourseRepository(UniversityDbContext context) : Repository<Course>(context), ICourseRepository
{
 
    public async Task<Course?> GetByTitleAsync(string name) => await _context.Courses.FirstOrDefaultAsync(c => c.Name==name);
}