using NIkoh.Domain.Entities.Persons;
using NIkoh.Domain.Entities.Requirements;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIkoh.Domain.Entities.Marriages;

public class Marriage : BaseEntity
{
    public string Description { get; set; }

    public string Healthy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long WomenId { get; set; }

    [ForeignKey(nameof(WomenId))]
    public Person? Women { get; set; }

    public long ManId { get; set; }

    [ForeignKey(nameof(ManId))]
    public Person? Man { get; set; }

    public long RequirementId { get; set; }
    public Requirement Requirements { get; set; }
}
