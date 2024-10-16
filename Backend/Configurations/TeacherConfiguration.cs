using Backend.Models.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.HasKey(t => t.Id);
        // Teacher -> Subjects (Many to Many)
        builder.HasMany(t => t.Subjects)
               .WithMany(s => s.Teachers);
    }
}
