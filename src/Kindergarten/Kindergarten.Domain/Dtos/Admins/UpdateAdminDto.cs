using System.Text.Json.Serialization;

namespace Kindergarten.Domain.Dtos.Admins;

public class UpdateAdminDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
