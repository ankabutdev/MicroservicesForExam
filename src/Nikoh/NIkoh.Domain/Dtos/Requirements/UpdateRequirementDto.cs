namespace NIkoh.Domain.Dtos.Requirements;

public class UpdateRequirementDto
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public long MarriageId { get; set; }
}
