using Kindergarten.Domain.Entities.Students;
using Kindergarten.Domain.Entities.Teachers;

namespace Kindergarten.Domain.Entities.Groups;

public class Group : BaseEntity
{
    public string Name { get; set; }

    public string Description { get; set; }

    public long AgeGroup { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public ICollection<Student> Students { get; set; }

    public ICollection<Teacher> Teachers { get; set; }

}
