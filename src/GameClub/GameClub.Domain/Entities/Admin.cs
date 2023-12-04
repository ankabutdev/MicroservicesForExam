namespace GameClub.Domain.Entities;

public class Admin : BaseEntity
{
    public string Name { get; set; }

    public string Password { get; set; }

    public IEnumerable<ScheduleOfChanges> ScheduleOfChanges { get; set; }

    public IEnumerable<History> Histories { get; set; }

}
