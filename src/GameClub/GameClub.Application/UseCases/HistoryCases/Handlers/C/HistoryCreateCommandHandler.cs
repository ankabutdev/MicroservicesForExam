using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.HistoryCases.Commands;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Handlers.C;

public class HistoryCreateCommandHandler : IRequestHandler<HistoryCreateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public HistoryCreateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(HistoryCreateCommand request, CancellationToken cancellationToken)
    {
        var history = _mapper.Map<History>(request);

        await _context.Histories
            .AddAsync(history,
            cancellationToken);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
