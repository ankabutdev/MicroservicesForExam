using AutoMapper;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Application.UseCases.ComputerCases.Commands;
using GameClub.Application.UseCases.PlayerCases.Commands;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using GameClub.Domain.DTOs.Admins;
using GameClub.Domain.DTOs.Computers;
using GameClub.Domain.DTOs.Players;
using GameClub.Domain.DTOs.ScheduleOfChanges;
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

        // Computers
        CreateMap<Computer, ComputerCreateCommand>().ReverseMap();
        CreateMap<Computer, ComputerUpdateCommand>().ReverseMap();

        CreateMap<ComputerCreateCommand, ComputerCreateDto>().ReverseMap();
        CreateMap<ComputerUpdateCommand, ComputerUpdateDto>().ReverseMap();

        // Players
        CreateMap<Player, PlayerCreateCommand>().ReverseMap();
        CreateMap<Player, PlayerUpdateCommand>().ReverseMap();

        CreateMap<PlayerCreateCommand, PlayerCreateDto>().ReverseMap();
        CreateMap<PlayerUpdateCommand, PlayerUpdateDto>().ReverseMap();

        // ScheduleOfChanges
        CreateMap<ScheduleOfChanges, ScheduleOfChangesCreateCommand>().ReverseMap();
        CreateMap<ScheduleOfChanges, ScheduleOfChangesUpdateCommand>().ReverseMap();

        CreateMap<ScheduleOfChangesCreateCommand, ScheduleOfChangesCreateDto>().ReverseMap();
        CreateMap<ScheduleOfChangesUpdateCommand, ScheduleOfChangesUpdateDto>().ReverseMap();

    }
}
