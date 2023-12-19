using System.Text.Json.Serialization;

namespace Olx.Application.DTOs.Categories;

public class UpdateCategoryDto
{
    [JsonIgnore]
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

}
