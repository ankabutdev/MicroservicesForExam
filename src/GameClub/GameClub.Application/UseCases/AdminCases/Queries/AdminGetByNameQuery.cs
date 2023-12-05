using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Queries;

public class AdminGetByNameQuery : IRequest<Admin>
{
    public string Name { get; set; }
}
