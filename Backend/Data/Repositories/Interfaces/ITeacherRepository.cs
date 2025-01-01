using Backend.Core.Models.Users;

namespace Backend.Data.Repositories.Interfaces;

public interface ITeacherRepository : IUserRepository<Teacher>
{
    Task<IEnumerable<Teacher>> GetTeachersBySubjectIdAsync(Guid subjectId);
}