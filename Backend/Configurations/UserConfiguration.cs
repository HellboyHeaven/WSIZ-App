using Backend.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasDiscriminator<string>("Role")
            .HasValue<Student>("Student")
            .HasValue<Teacher>("Teacher")
            .HasValue<Admin>("Admin");
    }
}