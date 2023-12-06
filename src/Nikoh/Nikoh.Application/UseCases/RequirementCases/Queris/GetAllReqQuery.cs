using MediatR;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.UseCases.RequirementCases.Queris;

public class GetAllReqQuery : IRequest<IEnumerable<Requirement>>
{
}
