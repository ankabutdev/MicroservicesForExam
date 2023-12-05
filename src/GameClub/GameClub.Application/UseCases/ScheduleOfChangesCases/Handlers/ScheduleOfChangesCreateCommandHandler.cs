using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Handlers;

public class ScheduleOfChangesCreateCommandHandler : IRequestHandler<ScheduleOfChangesCreateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ScheduleOfChangesCreateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(ScheduleOfChangesCreateCommand request,
        CancellationToken cancellationToken)
    {
        var soch = _mapper.Map<ScheduleOfChanges>(request);

        await _context.ScheduleOfChanges
            .AddAsync(soch, cancellationToken);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
