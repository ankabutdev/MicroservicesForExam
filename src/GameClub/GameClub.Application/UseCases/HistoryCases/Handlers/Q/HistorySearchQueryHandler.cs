using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.HistoryCases.Queries;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Handlers.Q;

public class HistorySearchQueryHandler : IRequestHandler<HistorySearchQuery, IQueryable<History>>
{
    private readonly IApplicationDbContext _context;

    public HistorySearchQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<History>> Handle(HistorySearchQuery request,
        CancellationToken cancellationToken)
    {
        var histories = _context.Histories
            .Where(x => x.Message.ToLower()
            .Contains(request.Message.ToLower()));

        return histories;
    }
}
