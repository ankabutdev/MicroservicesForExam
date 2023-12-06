using Kindergarten.Domain.Entities.Groups;
using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Queries;

public class SearchByGroupNameQuery : IRequest<IQueryable<Group>>
{
    public string Name { get; set; }
}
