using System.ComponentModel.DataAnnotations.Schema;

namespace GameClub.Domain.Entities;

public class Computer : BaseEntity
{
    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

    public IEnumerable<Player> Players { get; set; }

    public long ScheduleOfChangesId { get; set; }

    [ForeignKey("ScheduleOfChangesId")]
    public ScheduleOfChanges ScheduleOfChanges { get; set; }

    public long HistoryId { get; set; }

    [ForeignKey("HistoryId")]
    public History History { get; set; }
}
}
