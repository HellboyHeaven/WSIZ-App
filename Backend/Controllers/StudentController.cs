using Backend.Models.Users;
using Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class StudentController(IStudentRepository studentRepository) : ControllerBase
{
    private readonly IStudentRepository _studentRepository = studentRepository;

    [HttpGet("me")]
    [Authorize(Roles ="Student")]
    public async Task<ActionResult<Student>> GetMe()
    {
        var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        // Декодируем токен и извлекаем 'sub' (subject)
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var sub = jwtToken.Subject;

        var student = await  _studentRepository.GetByIdAsync(new Guid(sub));
        return Ok(student);
    } 


    // GET: api/<StudentController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
    {
        var students = await _studentRepository.GetAllAsync();
        return Ok(students);
    } 

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