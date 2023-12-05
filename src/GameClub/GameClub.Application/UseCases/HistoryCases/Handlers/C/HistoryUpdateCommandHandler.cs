using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.HistoryCases.Commands;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Handlers.C;

public class HistoryUpdateCommandHandler : IRequestHandler<HistoryUpdateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public HistoryUpdateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(HistoryUpdateCommand request, CancellationToken cancellationToken)
    {
        var history = _mapper.Map<History>(request);

        _context.Histories.Update(history);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
