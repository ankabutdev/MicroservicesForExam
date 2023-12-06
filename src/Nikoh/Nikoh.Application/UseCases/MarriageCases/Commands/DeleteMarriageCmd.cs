using MediatR;

namespace Nikoh.Application.UseCases.MarriageCases.Commands;

public class DeleteMarriageCmd : IRequest<bool>
{
    public long Id { get; set; }
}
