using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Queries;

public class PlayerSearchWithNickNameQuery : IRequest<IQueryable<Player>>
{
    public string NickName { get; set; }
}
