using MediatR;

namespace Nikoh.Application.UseCases.RequirementCases.Commands;

public class DeleteReqCmd : IRequest<bool>
{
    public long Id { get; set; }
}
