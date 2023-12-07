using System.Text.Json.Serialization;

namespace GameClub.Domain.DTOs.Admins;

public class AdminUpdateDto
{
    [JsonIgnore]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }
}
