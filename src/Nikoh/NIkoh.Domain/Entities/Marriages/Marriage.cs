using NIkoh.Domain.Entities.Requirements;

namespace NIkoh.Domain.Entities.Marriages;

public class Marriage : BaseEntity
{
    public string Description { get; set; }

    public string Healthy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long WomenId { get; set; }

    public long ManId { get; set; }

    public long RequirementId { get; set; }

}
