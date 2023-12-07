using Olx.Domain.Enums;

namespace Olx.Domain.Entities;

public class User
{
    public long Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string UserName { get; set; }

    public string Address { get; set; }

    public Role Role { get; set; }

    public ICollection<Announcements> Announcements { get; set; }
}
