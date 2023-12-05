using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Queries;

public class PlayerGetByIdQuery : IRequest<Player>
{
    public long Id { get; set; }
}
