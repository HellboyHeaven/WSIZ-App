using Backend.Models.Users;

namespace Backend.Models;

public class Lesson
{
    public Guid Id { get; set; }
    public Group? Group { get; set; }
    public Teacher? Teacher { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}