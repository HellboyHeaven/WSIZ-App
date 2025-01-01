using Backend.Core.Models;

namespace Backend.Data.Repositories.Interfaces;

public interface ILessonRepository : IRepository<Lesson>
{
    Task<List<Lesson>> GetLessonsByStudentIdAsync(Guid studentId);
    Task<List<Lesson>> GetLessonsByStudentIdAndDayAsync(Guid studentId, DateOnly date); 
}