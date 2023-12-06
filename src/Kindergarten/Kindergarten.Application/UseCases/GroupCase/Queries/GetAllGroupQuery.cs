using Kindergarten.Domain.Entities.Groups;
using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Queries;

public class GetAllGroupQuery : IRequest<IEnumerable<Group>>
{
}
