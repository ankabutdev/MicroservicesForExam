namespace GameClub.Domain.DTOs.Players;

public class PlayerCreateDto
{
    public string NickName { get; set; }

    public long HoursCount { get; set; }

    public long ComputerId { get; set; }
}
