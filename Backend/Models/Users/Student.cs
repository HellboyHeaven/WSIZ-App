namespace Backend.Models.Users;

public class Student : User
{
    public string StudentId { get; set; } = string.Empty;
    public Course? Course { get; set; }
    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public List<Subject> Subjects { get; set; } = new List<Subject>();
    public List<Grade> Grades { get; set; } = new List<Grade>();
}