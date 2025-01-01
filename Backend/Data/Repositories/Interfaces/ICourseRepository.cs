using Backend.Core.Models;

namespace Backend.Data.Repositories.Interfaces;

public interface ICourseRepository : IRepository<Course> {
    Task<Course?> GetByTitleAsync(string title);
  
}