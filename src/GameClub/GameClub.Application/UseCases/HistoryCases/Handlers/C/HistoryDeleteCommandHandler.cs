using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.HistoryCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.HistoryCases.Handlers.C;

public class HistoryDeleteCommandHandler : IRequestHandler<HistoryDeleteCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public HistoryDeleteCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(HistoryDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var history = await _context.Histories
            .FirstOrDefaultAsync(x => x.Id.Equals(request.Id),
            cancellationToken);

        if (history == null)
            return false;

        _context.Histories.Remove(history);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
