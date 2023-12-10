using MediatR;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<Category>
{
    public long Id { get; set; }
}
