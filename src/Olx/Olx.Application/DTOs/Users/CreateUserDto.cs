using Olx.Domain.Enums;

namespace Olx.Application.DTOs.Users;

public class CreateUserDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string UserName { get; set; }

    public string Address { get; set; }

    public Role Role { get; set; }

}
