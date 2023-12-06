using Kindergarten.Domain.Entities.Parents;
using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Queries;

public class GetAllParentQuery : IRequest<IEnumerable<Parent>>
{ }
