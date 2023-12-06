using Kindergarten.Domain.Entities.Students;

namespace Kindergarten.Domain.Entities.Parents;

public class Parent : BaseEntity
{
    public string MotherFullName { get; set; }

    public string FatherFullName { get; set; }

    public string PassportSeriaNumber { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public IEnumerable<Student> Students { get; set; }
}
