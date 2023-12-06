using Kindergarten.Domain.Entities.Groups;

namespace Kindergarten.Domain.Entities.Teachers;

public class Teacher : BaseEntity
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public ICollection<Group> Groups { get; set; }

}
