using System.Text.Json.Serialization;

namespace Kindergarten.Domain.Dtos.Teachers;

public class UpdateTeacherDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }
}
