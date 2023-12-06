using Kindergarten.Domain.Entities.Groups;
using Kindergarten.Domain.Entities.Parents;
using Kindergarten.Domain.Enums;

namespace Kindergarten.Domain.Entities.Students;

public class Student : BaseEntity
{
    public string FullName { get; set; }

    public Gender Gender { get; set; }

    public DateTime RegisteredAt { get; set; }

    public string Address { get; set; }

    public DateTime DateOfBirth { get; set; }

    public long ParentId { get; set; }

    public Parent Parent { get; set; }

    public long GroupId { get; set; }

    public Group Group { get; set; }
}
