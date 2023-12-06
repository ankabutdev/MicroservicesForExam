using AutoMapper;
using Nikoh.Application.UseCases.MarriageCases.Commands;
using Nikoh.Application.UseCases.PersonCases.Commands;
using Nikoh.Application.UseCases.RequirementCases.Commands;
using NIkoh.Domain.Dtos.Marriages;
using NIkoh.Domain.Dtos.Persons;
using NIkoh.Domain.Dtos.Requirements;
using NIkoh.Domain.Entities.Marriages;
using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.Mappers;

public class MappingConfiguration : Profile
{
    public MappingConfiguration()
    {
        // Marriage
        CreateMap<Marriage, CreateMarriageCmd>().ReverseMap();
        CreateMap<Marriage, UpdateMarriageCmd>().ReverseMap();

        CreateMap<CreateMarriageCmd, CreateMarriageDto>().ReverseMap();
        CreateMap<UpdateMarriageCmd, UpdateMarriageDto>().ReverseMap();

        // Requirements
        CreateMap<Requirement, CreateReqCmd>().ReverseMap();
        CreateMap<Requirement, UpdateReqCmd>().ReverseMap();

        CreateMap<CreateReqCmd, CreateRequirementDto>().ReverseMap();
        CreateMap<UpdateReqCmd, UpdateRequirementDto>().ReverseMap();

        // Persons
        CreateMap<Person, CreatePersonCmd>().ReverseMap();
        CreateMap<Person, UpdatePersonCmd>().ReverseMap();

        CreateMap<CreatePersonCmd, CreatePersonDto>().ReverseMap();
        CreateMap<UpdatePersonCmd, UpdatePersonDto>().ReverseMap();
    }
}
