using Backend.Core.Models.Users;

namespace Backend.Core.Responses;
public class StudentResponse : UserResponse
{
    public StudentResponse(Student student) : base(student) {
        StudentId = student.StudentId;
        Course = student.Course!.Name;
    }

    public string StudentId { get; set; } = string.Empty;
    public string Course { get; set; } = string.Empty;
    
}