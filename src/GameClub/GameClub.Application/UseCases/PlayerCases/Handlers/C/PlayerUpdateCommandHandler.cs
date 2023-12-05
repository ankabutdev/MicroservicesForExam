using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.PlayerCases.Commands;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.PlayerCases.Handlers.C;

public class PlayerUpdateCommandHandler : IRequestHandler<PlayerUpdateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PlayerUpdateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(PlayerUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var player = await _context
            .Players
            .FirstOrDefaultAsync(x => x.NickName == request.NickName,
            cancellationToken);

        if (player is not null)
            throw new Exception("Player already exists");

        player = _mapper.Map<Player>(request);

        _context.Players.Update(player);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
