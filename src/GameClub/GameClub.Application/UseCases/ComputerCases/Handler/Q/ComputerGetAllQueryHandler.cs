using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ComputerCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ComputerCases.Handler.Q;

public class ComputerGetAllQueryHandler : IRequestHandler<ComputerGetAllQuery,
    IEnumerable<Computer>>
{
    private readonly IApplicationDbContext _context;

    public ComputerGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Computer>> Handle(ComputerGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Computers.ToListAsync(cancellationToken);
    }
}
