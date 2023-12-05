using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Queries;

public class PlayerGetAllQuery : IRequest<IEnumerable<Player>>
{
}