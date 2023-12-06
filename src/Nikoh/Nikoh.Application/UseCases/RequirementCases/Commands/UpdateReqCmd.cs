using MediatR;

namespace Nikoh.Application.UseCases.RequirementCases.Commands;

public class UpdateReqCmd : IRequest<bool>
{
    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

}
