using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.ScheduleOfChangesCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Handlers;

public class ScheduleOfChangesGetAllQueryHandler :
    IRequestHandler<ScheduleOfChangesGetAllQuery, IEnumerable<ScheduleOfChanges>>
{
    private readonly IApplicationDbContext _context;

    public ScheduleOfChangesGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ScheduleOfChanges>> Handle(ScheduleOfChangesGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.ScheduleOfChanges.ToListAsync(cancellationToken);
    }
}
