using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces; 
using Microsoft.EntityFrameworkCore;

public class GradeRepository(UniversityDbContext context) : Repository<Grade>(context), IGradeRepository { }