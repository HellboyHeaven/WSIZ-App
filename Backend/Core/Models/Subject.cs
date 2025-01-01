using Backend.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Backend.Core.Models;

[Index(nameof(Name), nameof(Type), IsUnique = true)]
public class Subject
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
    [Required] public SubjectType Type { get; set; }
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Grade> Grades { get; set; } = new List<Grade>();
}

public enum SubjectType {
    Lecture,
    Laboratory,
    Workshop,
} 
