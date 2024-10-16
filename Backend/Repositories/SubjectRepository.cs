using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;

public class SubjectRepository(UniversityDbContext context) : Repository<Subject>(context), ISubjectRepository
{
       
}