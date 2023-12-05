using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Queries;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Handlers.Q;

public class PlayerSearchWithNickNameQueryHandler : IRequestHandler<PlayerSearchWithNickNameQuery, IQueryable<Player>>
{
    private readonly IApplicationDbContext _context;

    public PlayerSearchWithNickNameQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Player>> Handle(PlayerSearchWithNickNameQuery request,
        CancellationToken cancellationToken)
    {
        var players = _context.Players
            .Where(x => x.NickName.ToLower()
            .Contains(request.NickName.ToLower()));

        return players;
    }
}
