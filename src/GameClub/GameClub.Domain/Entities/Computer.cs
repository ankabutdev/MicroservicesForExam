namespace GameClub.Domain.Entities;

public class Computer : BaseEntity
{
    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

    public IEnumerable<Player> Players { get; set; }

}
