using System.Text.Json.Serialization;

namespace GameClub.Domain.DTOs.Computers;

public class ComputerUpdateDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

}