using Backend.Core.Extensions;
using Backend.Core.Models.Users;
using Backend.Core.Responses;
using Backend.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Application.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StudentController(IStudentRepository studentRepository) : ControllerBase
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    [HttpGet]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<Student>> GetMe()
    {
        var userId = HttpContext.GetUserIdFromToken();
        var student = await _studentRepository.GetByIdAsync(userId);

        if (student == null)
            return NotFound(student);

        var response = new StudentResponse(student);
        


        return Ok(response);
    }


    // GET: api/<StudentController>
   

    // GET api/<StudentController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetStudent(Guid id)
    {
        var students = await _studentRepository.GetByIdAsync(id);
        if (students == null)
        {
            return NotFound();
        }
        return Ok(students);
    }

    // POST api/<StudentController>
    [HttpPost]
    public async Task<ActionResult<Student>> PostStudent(Student student)
    {
        var studentId = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
        await _studentRepository.AddAsync(student);
        return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
    }

    // PUT api/<StudentController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<StudentController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}