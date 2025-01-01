using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Models.Users;
using Backend.Core.Models;

namespace Backend.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {

        builder.HasIndex(s => s.StudentId).IsUnique();
        // Student -> Groups (Many to Many)
        builder.HasMany(s => s.Groups)
               .WithMany(g => g.Students);

        // Student -> Lessons (Many to Many)
        builder.HasMany(s => s.Lessons)
               .WithMany(l => l.Students);

    }
}
