using MediatR;

namespace Nikoh.Application.UseCases.MarriageCases.Commands;

public class CreateMarriageCmd : IRequest<bool>
{
    public string Description { get; set; }

    public string Healthy { get; set; }

    public DateTime CreatedAt { get; set; }

    public long WomenId { get; set; }

    public long ManId { get; set; }

    public long RequirementId { get; set; }

}
