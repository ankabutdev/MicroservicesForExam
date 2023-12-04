using GameClub.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameClub.Domain.Entities;

public class ScheduleOfChanges : BaseEntity
{
    public IEnumerable<Computer> Computers { get; set; }

    public IEnumerable<Player> Players { get; set; }

    public string Description { get; set; }

    public double TotalPrice { get; set; }

    public ChangesStatus Status { get; set; }

    public long HistoryId { get; set; }

    [ForeignKey(nameof(HistoryId))]
    public History History { get; set; }

}
