using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Queries;

public class AdminGetByIdQuery : IRequest<Admin>
{
    public long Id { get; set; }
}
