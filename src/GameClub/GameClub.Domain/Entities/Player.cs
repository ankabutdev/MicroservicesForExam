namespace GameClub.Domain.Entities;

public class Player : BaseEntity
{
    public string NickName { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public DateTime EndDate { get; set; }

    public long HoursCount { get; set; }

    public long ComputerId { get; set; }

    public Computer Computer { get; set; }

    public ICollection<ScheduleOfChanges> ScheduleOfChanges { get; set; }
}
