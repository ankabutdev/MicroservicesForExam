using GameClub.Domain.Enums;
using MediatR;

namespace GameClub.Application.UseCases.ScheduleOfChangesCases.Commands;

public class ScheduleOfChangesUpdateCommand : IRequest<bool>
{
    public long Id { get; set; }

    public string Description { get; set; }

    public double TotalPrice { get; set; }

    public ChangesStatus Status { get; set; }

    public long AdminId { get; set; }

    public long PlayerId { get; set; }
}
