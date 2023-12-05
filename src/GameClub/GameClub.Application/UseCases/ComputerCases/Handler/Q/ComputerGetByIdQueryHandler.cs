using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ComputerCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ComputerCases.Handler.Q;

public class ComputerGetByIdQueryHandler : IRequestHandler<ComputerGetByIdQuery, Computer>
{
    private readonly IApplicationDbContext _context;

    public ComputerGetByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Computer> Handle(ComputerGetByIdQuery request, CancellationToken cancellationToken)
    {
        Computer? computer = await _context.Computers
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (computer is null)
            return new Computer();

        return computer;
    }
}
