using Backend.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models.Users;


public class Student : User
{
    [Required] public string StudentId { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
    [Required] public Course Course { get; set; }
    public List<Group> Groups { get; set; } = new List<Group>();
    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public List<Subject> Subjects { get; set; } = new List<Subject>();
    public List<Grade> Grades { get; set; } = new List<Grade>();
}