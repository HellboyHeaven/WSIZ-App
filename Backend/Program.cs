using Backend.Core.Attributes;
using Backend.Core.Models;
using Backend.Core.Models.Users;
using Backend.Data;
using Backend.Data.Repositories;
using Backend.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", policy =>
    {
        policy.WithOrigins("https://example.com")  // Разрешить только с этого источника
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// ������������ ����������� �������, ��������, ��� ������������� ������������ � DI-����������
services.AddAutoMapper(typeof(Program));
services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
services.AddSingleton(configuration);



// ����������� ������������


ConfigureRepositories(services);
ConfigureServices(services);



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<UniversityDbContext>(options =>
   options.UseNpgsql(
    configuration.GetConnectionString(nameof(UniversityDbContext)),
    o => o.MapEnum<LessonState>("lesson_state").MapEnum<SubjectType>("subject_type")
    ));



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

app.UseCors("AllowSpecificOrigin");


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


void ConfigureServices(IServiceCollection services)
{
   
    var serviceTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.GetCustomAttribute<ServiceAttribute>() != null)
        .ToList();

    foreach (var serviceType in serviceTypes)
    {
        services.AddScoped(serviceType);
    }


}

void ConfigureRepositories(IServiceCollection services)
{
    var typesWithRepositoryAttribute = Assembly.GetExecutingAssembly().GetTypes()
          .Where(t => t.GetCustomAttribute<RepositoryAttribute>() != null)
          .ToList();


    services.AddScoped<IUserRepository<User>, UserRepository<User>>();



    //services.AddScoped(typeof(IUserRepository<>), typeof(UserRepository<>));

    foreach (var type in typesWithRepositoryAttribute)
    {
        var interfaces = type.GetInterfaces().ToList();
        if (interfaces.Any())
        {
            services.AddScoped(interfaces.Last(), type);
        }
    }
}

