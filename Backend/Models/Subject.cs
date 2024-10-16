using Backend.Models.Users;

namespace Backend.Models;


public class Subject
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Grade> Grades { get; set; } = new List<Grade>();
}
