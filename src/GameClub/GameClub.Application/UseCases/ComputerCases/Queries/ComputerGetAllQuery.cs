using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.ComputerCases.Queries;

public class ComputerGetAllQuery : IRequest<IEnumerable<Computer>>
{
}
