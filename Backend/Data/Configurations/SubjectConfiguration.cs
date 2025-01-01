using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Core.Models;

namespace Backend.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(t => t.Id);
        // Subject -> Students (Many to Many)
        builder.HasMany(s => s.Students)
               .WithMany(st => st.Subjects);
        
        
    }
}
