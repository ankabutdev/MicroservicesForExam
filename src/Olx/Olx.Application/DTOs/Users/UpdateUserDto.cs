using Olx.Domain.Enums;
using System.Text.Json.Serialization;

namespace Olx.Application.DTOs.Users;

public class UpdateUserDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string UserName { get; set; }

    public string Address { get; set; }

    public Role Role { get; set; }

}
