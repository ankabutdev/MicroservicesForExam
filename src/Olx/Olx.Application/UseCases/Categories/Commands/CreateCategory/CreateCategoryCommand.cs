using MediatR;

namespace Olx.Application.UseCases.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<bool>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

}
