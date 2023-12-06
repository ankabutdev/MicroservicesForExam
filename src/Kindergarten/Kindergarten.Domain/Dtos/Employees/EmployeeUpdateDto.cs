using Kindergarten.Domain.Enums;

namespace Kindergarten.Domain.Dtos.Employees;

public class EmployeeUpdateDto
{
    public long Id { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public Gender Gender { get; set; }
}
