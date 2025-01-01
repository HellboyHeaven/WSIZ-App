using Backend.Core.Attributes;
using Backend.Core.Models;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;

[Repository]
public class SubjectRepository(UniversityDbContext context) : Repository<Subject>(context), ISubjectRepository
{
       
}