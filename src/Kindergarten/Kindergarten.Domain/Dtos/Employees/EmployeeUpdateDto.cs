using Kindergarten.Domain.Enums;
using System.Text.Json.Serialization;

namespace Kindergarten.Domain.Dtos.Employees;

public class EmployeeUpdateDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public Gender Gender { get; set; }
}
