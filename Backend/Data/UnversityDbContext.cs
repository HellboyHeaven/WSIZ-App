using Backend.Core.Models;
using Backend.Core.Models.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Backend.Data
{
    public class UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new CourseConfiguration());
            //modelBuilder.ApplyConfiguration(new GroupConfiguration());
            //modelBuilder.ApplyConfiguration(new LessonConfiguration());
            ////modelBuilder.ApplyConfiguration(new StudentConfiguration());
            ////modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            //modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            //modelBuilder.ApplyConfiguration(new GradeConfiguration());
            ////modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            ///
            modelBuilder.HasPostgresEnum<LessonState>();
            modelBuilder.HasPostgresEnum<SubjectType>();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


        
    }
}
