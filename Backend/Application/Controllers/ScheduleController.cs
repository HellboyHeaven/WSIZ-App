using Backend.Core.Extensions;
using Backend.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Backend.Application.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScheduleController(ILessonRepository lessonRepository) : ControllerBase
{
    private readonly ILessonRepository _lessonRepository = lessonRepository;

    [HttpGet("student")]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult> GetSchedule()
    {
        var userId = HttpContext.GetUserIdFromToken();
        var lessons = await _lessonRepository.GetLessonsByStudentIdAsync(userId);
        System.Console.WriteLine(lessons.Count);

        var response = new Dictionary<DateOnly, List<LessonResponse>>();
        foreach (var lesson in lessons) {
            var key = lesson.Date;
            var value = new LessonResponse(lesson);
            if (!response.ContainsKey(key)) {
                 response[key] = new List<LessonResponse>();
            }
            response[key].Add(value);
           
        }        
      
        return Ok(response);
    }
}