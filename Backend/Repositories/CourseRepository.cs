using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class CourseRepository(UniversityDbContext context) : Repository<Course>(context), ICourseRepository { }