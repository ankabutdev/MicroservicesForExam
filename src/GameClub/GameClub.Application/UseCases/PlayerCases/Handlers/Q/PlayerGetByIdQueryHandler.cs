using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.PlayerCases.Handlers.Q;

public class PlayerGetByIdQueryHandler : IRequestHandler<PlayerGetByIdQuery, Player>
{
    private readonly IApplicationDbContext _context;

    public PlayerGetByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Player> Handle(PlayerGetByIdQuery request, CancellationToken cancellationToken)
    {
        Player? player = await _context.Players
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (player is null)
            return new Player();

        return player;
    }
}
