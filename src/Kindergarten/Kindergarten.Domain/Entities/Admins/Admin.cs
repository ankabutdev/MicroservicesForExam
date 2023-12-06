namespace Kindergarten.Domain.Entities.Admins;

public class Admin : BaseEntity
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
