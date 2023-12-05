namespace GameClub.Domain.DTOs.Computers;

public class ComputerCreateDto
{
    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

    public long ScheduleOfChangesId { get; set; }

}
