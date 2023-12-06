using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Commands;

public class CreateGroupCmd : IRequest<bool>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public long AgeGroup { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
