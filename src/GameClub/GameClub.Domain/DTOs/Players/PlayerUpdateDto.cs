namespace GameClub.Domain.DTOs.Players;

public class PlayerUpdateDto
{
    public long Id { get; set; }

    public string NickName { get; set; }

    public long HoursCount { get; set; }

    public long ComputerId { get; set; }
}
