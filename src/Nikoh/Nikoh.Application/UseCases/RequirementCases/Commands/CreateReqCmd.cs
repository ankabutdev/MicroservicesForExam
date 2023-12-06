using MediatR;

namespace Nikoh.Application.UseCases.RequirementCases.Commands;

public class CreateReqCmd : IRequest<bool>
{
    public string Title { get; set; }

    public string Description { get; set; }

}
