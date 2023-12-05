using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Commands;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.PlayerCases.Handlers.C;

public class PlayerCreateCommandHandler : IRequestHandler<PlayerCreateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PlayerCreateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(PlayerCreateCommand request,
        CancellationToken cancellationToken)
    {
        var player = await _context.Players
            .FirstOrDefaultAsync(x => x.NickName == request.NickName);

        if (player is not null)
            return false;

        player = _mapper.Map<Player>(request);

        await _context.Players.AddAsync(player, cancellationToken);
        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
