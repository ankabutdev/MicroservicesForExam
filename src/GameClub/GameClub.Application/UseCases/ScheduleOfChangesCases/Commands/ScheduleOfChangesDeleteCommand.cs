using MediatR;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;

public class ScheduleOfChangesDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
