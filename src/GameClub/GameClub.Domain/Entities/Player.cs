using System.ComponentModel.DataAnnotations.Schema;

namespace GameClub.Domain.Entities;

public class Player : BaseEntity
{
    public string NickName { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public DateTime EndDate { get; set; }

    public long HoursCount { get; set; }

    public long ComputerId { get; set; }

    [ForeignKey(nameof(ComputerId))]
    public Computer Computer { get; set; }

    public long ScheduleOfChangesId { get; set; }

    [ForeignKey(nameof(ScheduleOfChangesId))]
    public ScheduleOfChanges ScheduleOfChanges { get; set; }
}
