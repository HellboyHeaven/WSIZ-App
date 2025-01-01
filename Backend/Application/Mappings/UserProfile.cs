using AutoMapper;
using Backend.Core.DTOs.Auth;
using Backend.Core.Models;
using Backend.Core.Models.Users;
using Backend.Data.Repositories.Interfaces;
using System.Diagnostics;
using System.Text;

namespace Backend.Application.Mappings;


// Профиль для маппинга
public class UserProfile : Profile
{
    public UserProfile()
    {


        // Маппинг между DTO и сущностями
        CreateMap<StudentRegisterDto, Student>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassword(src.Password)))
            .ForAllMembers(opt => opt.AllowNull());
        ;

        // Маппинг из TeacherRegisterDto в Teacher
        CreateMap<TeacherRegisterDto, Teacher>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassword(src.Password)));

        // Маппинг из RegisterDto в User
        CreateMap<RegisterDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => HashPassword(src.Password)));

        // Маппинг из LoginDto в User (для логина)
        CreateMap<LoginDto, User>();
    }

    private readonly ICourseRepository _courseRepository;

    private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

}

