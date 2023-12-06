using AutoMapper;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using Kindergarten.Domain.Dtos.Admins;
using Kindergarten.Domain.Dtos.Employees;
using Kindergarten.Domain.Dtos.Groups;
using Kindergarten.Domain.Dtos.Parents;
using Kindergarten.Domain.Dtos.Students;
using Kindergarten.Domain.Entities.Admins;
using Kindergarten.Domain.Entities.Employees;
using Kindergarten.Domain.Entities.Groups;
using Kindergarten.Domain.Entities.Parents;
using Kindergarten.Domain.Entities.Students;

namespace Kindergarten.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Admins
        CreateMap<Admin, CreateAdminCommand>().ReverseMap();
        CreateMap<Admin, UpdateAdminCommand>().ReverseMap();

        CreateMap<CreateAdminCommand, CreateAdminDto>().ReverseMap();
        CreateMap<UpdateAdminCommand, UpdateAdminDto>().ReverseMap();

        // Employees
        CreateMap<Employee, EmpCreateCmd>().ReverseMap();
        CreateMap<Employee, EmpUpdateCmd>().ReverseMap();

        CreateMap<EmpCreateCmd, EmployeeCreateDto>().ReverseMap();
        CreateMap<EmpUpdateCmd, EmployeeUpdateDto>().ReverseMap();

        // Groups
        CreateMap<Group, CreateGroupCmd>().ReverseMap();
        CreateMap<Group, UpdateGroupCmd>().ReverseMap();

        CreateMap<CreateGroupCmd, GroupCreateDto>().ReverseMap();
        CreateMap<UpdateGroupCmd, GroupUpdateDto>().ReverseMap();

        // Parents
        CreateMap<Parent, CreateParentCmd>().ReverseMap();
        CreateMap<Parent, UpdateParentCmd>().ReverseMap();

        CreateMap<CreateParentCmd, CreateParentDto>().ReverseMap();
        CreateMap<UpdateParentCmd, UpdateParentDto>().ReverseMap();

        // Students
        CreateMap<Student, CreateStudentCmd>().ReverseMap();
        CreateMap<Student, UpdateStudentCmd>().ReverseMap();

        CreateMap<CreateStudentCmd, CreateStudnetDto>().ReverseMap();
        CreateMap<UpdateStudentCmd, UpdateStudentDto>().ReverseMap();
    }
}
