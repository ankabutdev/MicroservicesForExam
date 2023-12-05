using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Handlers;

public class ScheduleOfChangesGetByIdQueryHandler :
    IRequestHandler<ScheduleOfChangesGetByIdQuery, ScheduleOfChanges>
{
    private readonly IApplicationDbContext _context;

    public ScheduleOfChangesGetByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ScheduleOfChanges> Handle(ScheduleOfChangesGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        ScheduleOfChanges? soch = await _context.ScheduleOfChanges
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (soch is null)
            return new ScheduleOfChanges();

        return soch;
    }
}