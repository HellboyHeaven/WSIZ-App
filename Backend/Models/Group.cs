using Backend.Models.Users;

namespace Backend.Models;

public class Group
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public Subject? Subject { get; set; }
}