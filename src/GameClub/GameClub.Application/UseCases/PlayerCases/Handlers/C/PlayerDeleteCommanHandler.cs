using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.PlayerCases.Handlers.C;

public class PlayerDeleteCommanHandler : IRequestHandler<PlayerDeleteCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public PlayerDeleteCommanHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(PlayerDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var player = await _context.Players
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (player == null)
            return false;

        _context.Players.Remove(player);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
