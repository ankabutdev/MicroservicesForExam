namespace Olx.Application.DTOs.Categories;

public class CreateCategoryDto
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}