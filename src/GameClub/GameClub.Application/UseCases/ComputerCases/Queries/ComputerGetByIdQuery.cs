using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.ComputerCases.Queries;

public class ComputerGetByIdQuery : IRequest<Computer>
{
    public long Id { get; set; }
}
