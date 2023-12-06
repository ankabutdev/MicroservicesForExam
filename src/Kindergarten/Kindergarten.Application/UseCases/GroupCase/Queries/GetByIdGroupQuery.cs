using Kindergarten.Domain.Entities.Groups;
using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Queries;

public class GetByIdGroupQuery : IRequest<Group>
{
    public long Id { get; set; }
}
