using Backend.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models;

[Index(nameof(Name), IsUnique = true)]
public class Course
{
    [Key] public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Student> Students { get; set; } = new List<Student>();
}
