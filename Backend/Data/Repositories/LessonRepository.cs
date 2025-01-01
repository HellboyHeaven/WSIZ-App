using Backend.Core.Attributes;
using Backend.Core.Models;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

[Repository]
public class LessonRepository(UniversityDbContext context) : Repository<Lesson>(context), ILessonRepository
{
    public Task<List<Lesson>> GetLessonsByStudentIdAndDayAsync(Guid studentId, DateOnly date)
        => _context.Lessons
        .Include(l => l.Students)
        .Include(l => l.Teacher)
        .Include(l => l.Subject)
        .Where(lesson => lesson.Date == date)
       
        .Where(lesson => lesson.Students.Any(student => student.Id == studentId))
        .ToListAsync();

    public Task<List<Lesson>> GetLessonsByStudentIdAsync(Guid studentId)
    {
        var date = DateTime.Today;
        int week = (int) (date.DayOfWeek + 6) % 7;
        var monday = date.AddDays(-week); 
        var sunday = date.AddDays(6-week);

        return _context.Lessons
        .Include(l => l.Students)
        .Include(l => l.Teacher)
        .Include(l => l.Subject)
        .Where(lesson => lesson.Students.Any(student => student.Id == studentId))
        .Where(lesson => lesson.Date >= DateOnly.FromDateTime(monday) && lesson.Date <= DateOnly.FromDateTime(sunday) )
        .OrderByDescending(lesson => lesson.StartTime)
        .ToListAsync();
    }

}