using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


public class GroupRepository(UniversityDbContext context) : Repository<Group>(context), IGroupRepository
{
}