using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Commands;

public class UpdateGroupCmd : IRequest<bool>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public long AgeGroup { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
