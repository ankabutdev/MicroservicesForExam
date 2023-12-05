using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Commands;

public class PlayerDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
