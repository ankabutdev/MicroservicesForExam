using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Queries;

public class ScheduleOfChangesGetByIdQuery : IRequest<ScheduleOfChanges>
{
    public long Id { get; set; }
}
