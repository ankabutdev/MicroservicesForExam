using Kindergarten.Domain.Enums;

namespace Kindergarten.Domain.Entities.Employees;

public class Employee : BaseEntity
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public Gender Gender { get; set; }

}
