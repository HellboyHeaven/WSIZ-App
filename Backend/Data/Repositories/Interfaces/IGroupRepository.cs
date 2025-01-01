using Backend.Core.Models;

namespace Backend.Data.Repositories.Interfaces;
public interface IGroupRepository : IRepository<Group>
{
    Task<Group?> GetByTitleAsync(string title);
}