using Backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(t => t.Id);
        // Grade -> Subject (Many to One)
        builder.HasOne(g => g.Subject)
              .WithMany(s => s.Grades);

        // Grade -> Student (Many to One)
        builder.HasOne(g => g.Student)
               .WithMany(s => s.Grades);
    }
}
