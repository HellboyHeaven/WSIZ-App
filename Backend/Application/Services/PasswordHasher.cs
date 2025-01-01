using Backend.Core.Attributes;
using Microsoft.CodeAnalysis.Scripting;

namespace Backend.Application.Services;


[Service]
public class PasswordHasher
{
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
