using GameClub.Domain.Enums;

namespace GameClub.Domain.Entities;

public class ScheduleOfChanges : BaseEntity
{
    public string Description { get; set; }

    public double TotalPrice { get; set; }

    public ChangesStatus Status { get; set; }

    public long AdminId { get; set; }

    public Admin Admin { get; set; }

    public long PlayerId { get; set; }

    public Player Player { get; set; }

}
