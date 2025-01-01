using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Models.Users;

namespace Backend.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {

        // Teacher -> Subjects (Many to Many)
        builder.HasMany(t => t.Subjects)
               .WithMany(s => s.Teachers);
    }
}
