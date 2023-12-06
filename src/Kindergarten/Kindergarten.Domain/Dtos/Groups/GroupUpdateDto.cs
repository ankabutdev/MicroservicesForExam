namespace Kindergarten.Domain.Dtos.Groups;

public class GroupUpdateDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long AgeGroup { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
