using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Handlers;

public class ScheduleOfChangesUpdateCommandHandler :
    IRequestHandler<ScheduleOfChangesUpdateCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ScheduleOfChangesUpdateCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(ScheduleOfChangesUpdateCommand request,
        CancellationToken cancellationToken)
    {
        var soch = _mapper.Map<ScheduleOfChanges>(request);

        _context.ScheduleOfChanges.Update(soch);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
