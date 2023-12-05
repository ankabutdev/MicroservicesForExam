using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.HistoryCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.HistoryCases.Handlers.Q;

public class HistoryGetAllQueryHandler : IRequestHandler<HistoryGetAllQuery, IEnumerable<History>>
{
    private readonly IApplicationDbContext _context;

    public HistoryGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<History>> Handle(HistoryGetAllQuery request, CancellationToken cancellationToken)
    {
        return await _context.Histories.ToListAsync(cancellationToken);
    }
}
