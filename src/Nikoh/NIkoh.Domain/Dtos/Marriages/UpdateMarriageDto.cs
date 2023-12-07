using System.Text.Json.Serialization;

namespace NIkoh.Domain.Dtos.Marriages;

public class UpdateMarriageDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Description { get; set; }

    public string Healthy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long WomenId { get; set; }

    public long ManId { get; set; }

    public long RequirementId { get; set; }

}
