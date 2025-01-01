using Backend.Core.Models;

public class LessonResponse
{
    public LessonResponse(Lesson lesson) {
        Subject = lesson.Subject.Name;
        Type = lesson.Subject.Type.ToString();
        State = lesson.State.ToString();
        Room = lesson.Room;
        Teacher = lesson.Teacher!.ToString();
        StartTime = lesson.StartTime;
        EndTime = lesson.EndTime;
    }

    public string Subject {get; set;} = string.Empty;
    public string Type {get; set;} = string.Empty;
    public string State {get; set;} = string.Empty;
    public string Room {get; set;} = string.Empty;
    public string Teacher {get; set;} = string.Empty;
    public TimeOnly StartTime {get; set;}
    public TimeOnly EndTime {get; set;}
    
}