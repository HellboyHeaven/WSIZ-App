using Backend.Core.Attributes;
using Backend.Core.Models;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


[Repository]
public class GroupRepository(UniversityDbContext context) : Repository<Group>(context), IGroupRepository
{
    public Task<Group?> GetByTitleAsync(string name) => _context.Groups.FirstOrDefaultAsync(o => o.Name == name);
}