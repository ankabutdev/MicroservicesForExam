using MediatR;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.UseCases.RequirementCases.Queris;

public class GetByIdReqQuery : IRequest<Requirement>
{
    public long Id { get; set; }
}
