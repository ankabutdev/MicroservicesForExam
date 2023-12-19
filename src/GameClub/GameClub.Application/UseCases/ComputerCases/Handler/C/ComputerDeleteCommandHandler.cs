using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ComputerCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ComputerCases.Handler.C;

public class ComputerDeleteCommandHandler : IRequestHandler<ComputerDeleteCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public ComputerDeleteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ComputerDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var computer = await _context.Computers.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (computer == null)
            return false;

        _context.Computers.Remove(computer);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
