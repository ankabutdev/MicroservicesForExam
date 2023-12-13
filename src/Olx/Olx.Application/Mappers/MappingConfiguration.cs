using AutoMapper;
using Olx.Application.DTOs.Announcements;
using Olx.Application.DTOs.Categories;
using Olx.Application.DTOs.Users;
using Olx.Application.UseCases.Announcements.Commands.CreateAnnouncement;
using Olx.Application.UseCases.Announcements.Commands.UpdateAnnouncement;
using Olx.Application.UseCases.Categories.Commands.CreateCategory;
using Olx.Application.UseCases.Categories.Commands.UpdateCategory;
using Olx.Application.UseCases.Users.Commands.CreateUser;
using Olx.Application.UseCases.Users.Commands.UpdateUser;
using Olx.Domain.Entities;

namespace Olx.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Announcements
        CreateMap<Announcement, CreateAnnouncementCommand>().ReverseMap();
        CreateMap<Announcement, UpdateAnnouncementCommand>().ReverseMap();

        CreateMap<CreateAnnouncementCommand, CreateAnnouncementDto>().ReverseMap();
        CreateMap<UpdateAnnouncementCommand, UpdateAnnouncementDto>().ReverseMap();

        // Users
        CreateMap<User, CreateUserCommand>().ReverseMap();
        CreateMap<User, UpdateUserCommand>().ReverseMap();

        CreateMap<CreateUserCommand, CreateUserDto>().ReverseMap();
        CreateMap<UpdateUserCommand, UpdateUserDto>().ReverseMap();

        // Categories
        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

        CreateMap<CreateCategoryCommand, CreateCategoryDto>().ReverseMap();
        CreateMap<UpdateCategoryCommand, UpdateCategoryDto>().ReverseMap();
    }
}
