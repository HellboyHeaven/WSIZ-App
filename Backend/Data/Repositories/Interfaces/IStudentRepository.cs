using Backend.Core.Models.Users;

namespace Backend.Data.Repositories.Interfaces;

public interface IStudentRepository : IUserRepository<Student>
{
    Task<IEnumerable<Student>> GetStudentsByGroupIdAsync(Guid groupId);

    
}