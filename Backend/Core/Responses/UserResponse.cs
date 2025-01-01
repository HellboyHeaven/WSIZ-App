using Backend.Core.Models.Users;

namespace Backend.Core.Responses;

public class UserResponse
{
    public UserResponse(User user) {
        Login = user.Login;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        BirthDay = user.BirthDay;
    }

    public string Login { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateOnly BirthDay { get; set; }
}
