using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Queries;

public class ScheduleOfChangesGetAllQuery : IRequest<IEnumerable<ScheduleOfChanges>>
{
}
