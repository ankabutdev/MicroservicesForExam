using MediatR;

namespace Olx.Application.UseCases.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<bool>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}
