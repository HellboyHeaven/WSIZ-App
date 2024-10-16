using Backend.Models.Users;

namespace Backend.Models;

public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new List<Student>();
}
