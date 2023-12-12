using MediatR;

namespace Olx.Application.UseCases.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<bool>
{
    public long Id { get; set; }
}
