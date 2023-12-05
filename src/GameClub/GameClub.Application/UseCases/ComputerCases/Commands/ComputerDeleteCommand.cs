using MediatR;

namespace GameClub.Application.UseCases.ComputerCases.Commands;

public class ComputerDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
