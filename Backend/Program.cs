using Backend.Data;
using Backend.Models;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using Backend.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;



// Регистрируем необходимые сервисы, например, для использования конфигурации в DI-контейнере
builder.Services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
builder.Services.AddSingleton(configuration);

// Регистрация репозиториев
services.AddScoped<ICourseRepository, CourseRepository>();
services.AddScoped<IGroupRepository, GroupRepository>();
services.AddScoped<ILessonRepository, LessonRepository>();
services.AddScoped<IUserRepository, UserRepository>();
services.AddScoped<IStudentRepository, StudentRepository>();
services.AddScoped<ITeacherRepository, TeacherRepository>();
services.AddScoped<ISubjectRepository, SubjectRepository>();
services.AddScoped<IGradeRepository, GradeRepository>();
services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
services.AddScoped<TokenService>();
services.AddScoped<AuthService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<UniversityDbContext>(options =>
   options.UseNpgsql(configuration.GetConnectionString(nameof(UniversityDbContext))));


services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            var jwtSettings = configuration.GetSection("Jwt").Get<JwtSettings>();
           
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
            };
        });





var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseHttpsRedirection();

app.UseAuthorization();
//app.UseAuthentication();

app.MapControllers();

app.Run();
