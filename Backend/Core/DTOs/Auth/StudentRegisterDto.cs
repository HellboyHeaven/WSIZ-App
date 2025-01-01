using System.ComponentModel.DataAnnotations;

namespace Backend.Core.DTOs.Auth;

public class StudentRegisterDto : RegisterDto
{
    required public string StudentId { get; set; } = string.Empty;
    required public string CourseName { get; set; } = string.Empty;
}