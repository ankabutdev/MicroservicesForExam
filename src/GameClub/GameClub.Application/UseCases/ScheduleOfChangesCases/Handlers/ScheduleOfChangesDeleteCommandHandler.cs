using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Handlers;

public class ScheduleOfChangesDeleteCommandHandler :
    IRequestHandler<ScheduleOfChangesDeleteCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public ScheduleOfChangesDeleteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ScheduleOfChangesDeleteCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var soch = await _context.ScheduleOfChanges
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (soch == null)
            return false;

        _context.ScheduleOfChanges.Remove(soch);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
