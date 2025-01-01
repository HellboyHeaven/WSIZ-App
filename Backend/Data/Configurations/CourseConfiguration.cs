﻿using Backend.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Students)
               .WithOne(s => s.Course)
               .HasForeignKey(s => s.CourseId);
    }
}