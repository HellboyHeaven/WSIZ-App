using Backend.Models.Users;

namespace Backend.Repositories.Interfaces;

public interface ITeacherRepository : IUserRepository
{
    Task<IEnumerable<Teacher>> GetTeachersBySubjectIdAsync(Guid subjectId);
}