using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Configurations;
public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(t => t.Id);
        // Group -> Students (One to Many)
        builder.HasMany(g => g.Students)
               .WithMany(s => s.Groups);

        // Group -> Subject (One to One)
        builder.HasOne(g => g.Subject)
               .WithMany(s => s.Groups);
    }
}