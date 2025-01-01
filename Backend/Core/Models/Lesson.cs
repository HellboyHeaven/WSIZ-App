using Backend.Core.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models;

public class Lesson
{
    [Key] public Guid Id { get; set; }
    [Required] public Subject Subject { get; set; }
    [Required] public LessonState State { get; set; }
    [Required] public string Room {get; set; } = string.Empty;
    [Required] public Group? Group { get; set; }
    [Required] public Teacher? Teacher { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    [Required] public DateOnly Date {get; set; } = new DateOnly();
    [Required] public TimeOnly StartTime { get; set; }
    [Required] public TimeOnly EndTime { get; set; }

   
}


public enum LessonState {
    Class,
    Exam,
    Canceled
}
