using MediatR;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Categories.Queries.GetAllCategory;

public class GetAllCategoryQuery : IRequest<IEnumerable<Category>>
{
}
