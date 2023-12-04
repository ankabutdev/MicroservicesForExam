using AutoMapper;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Domain.DTOs.Admins;
using GameClub.Domain.Entities;

namespace GameClub.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Admins
        CreateMap<Admin, CreateAdminCommand>().ReverseMap();
        CreateMap<Admin, UpdateAdminCommand>().ReverseMap();

        CreateMap<CreateAdminCommand, AdminCreateDto>().ReverseMap();
        CreateMap<UpdateAdminCommand, AdminUpdateDto>().ReverseMap();

        // ...
    }
}
