namespace Backend.Models.Users;


public class Teacher : User
{
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public List<Subject> Subjects { get; set; } = new List<Subject>();
}