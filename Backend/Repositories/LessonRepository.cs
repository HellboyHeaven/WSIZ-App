using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class LessonRepository(UniversityDbContext context) : Repository<Lesson>(context), ILessonRepository
{
        
}