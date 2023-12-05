using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.PlayerCases.Handlers.Q;

public class PlayerGetAllQueryHandler : IRequestHandler<PlayerGetAllQuery, IEnumerable<Player>>
{
    private readonly IApplicationDbContext _context;

    public PlayerGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Player>> Handle(PlayerGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Players.ToListAsync(cancellationToken);
    }
}
