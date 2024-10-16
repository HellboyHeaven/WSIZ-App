using Backend.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(t => t.Id);
        // Student -> Groups (Many to Many)
        builder.HasMany(s => s.Groups)
               .WithMany(g => g.Students);

        // Student -> Lessons (Many to Many)
        builder.HasMany(s => s.Lessons)
               .WithMany(l => l.Students);
    }
}
