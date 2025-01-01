using Backend.Core.Models.Users;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models;
public class Grade
{
    [Key] public Guid Id { get; set; }
    [Required] public Subject? Subject { get; set; }
    [Required] public Student? Student { get; set; }
    [Required] public float Score { get; set; }
}