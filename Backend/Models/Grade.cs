using Backend.Models.Users;

namespace Backend.Models;
public class Grade
{
    public int Id { get; set; }
    public Subject? Subject { get; set; }
    public Student? Student { get; set; }
    public float Score { get; set; }
}