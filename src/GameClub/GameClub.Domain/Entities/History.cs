namespace GameClub.Domain.Entities;

public class History : BaseEntity
{
    public string Message { get; set; }

    public string Description { get; set; }

    public long ComputerId { get; set; }

    public ICollection<Computer> Computers { get; set; }

    public DateTime CreatedAt { get; set; }

    public IEnumerable<ScheduleOfChanges> ScheduleOfChanges { get; set; }

}
