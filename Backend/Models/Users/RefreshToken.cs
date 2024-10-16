namespace Backend.Models.Users;

public class RefreshToken
{
    public Guid Id { get; set; }
    public string Token { get; set; } = string.Empty;       // Сам токен
    public DateTime ExpiryDate { get; set; }  // Время истечения
    public User? User { get; set; }
}