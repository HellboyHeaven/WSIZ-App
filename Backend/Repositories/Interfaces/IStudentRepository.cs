using Backend.Models.Users;

namespace Backend.Repositories.Interfaces;

public interface IStudentRepository : IUserRepository
{
    Task<IEnumerable<Student>> GetStudentsByGroupIdAsync(Guid groupId);
}