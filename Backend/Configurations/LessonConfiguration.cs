using Backend.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.HasKey(t => t.Id);
        // Lesson -> Group (Many to One)
        builder.HasOne(l => l.Group)
               .WithMany(g=> g.Lessons);


        // Lesson -> Teacher (Many to One)
        builder.HasOne(l => l.Teacher)
               .WithMany(t => t.Lessons);
             
    }
}

