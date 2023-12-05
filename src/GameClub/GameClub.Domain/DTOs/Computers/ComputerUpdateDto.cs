using System.Reflection.Emit;

namespace GameClub.Domain.DTOs.Computers;

public class ComputerUpdateDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

    public long ScheduleOfChangesId { get; set; }
}
