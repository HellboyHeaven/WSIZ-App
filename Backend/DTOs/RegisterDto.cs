namespace Backend.DTOs;

public class RegisterDto
{
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateOnly BirthDay { get; set; }
    public required string Role { get; set; }
    public string Course { get; set; } = string.Empty;

}