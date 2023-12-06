using GameClub.Domain.Enums;

namespace GameClub.Domain.DTOs.ScheduleOfChanges;

public class ScheduleOfChangesUpdateDto
{
    public long Id { get; set; }

    public string Description { get; set; }

    public double TotalPrice { get; set; }

    public ChangesStatus Status { get; set; }

    public long AdminId { get; set; }

    public long PlayerId { get; set; }
}
