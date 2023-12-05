using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Commands;

public class PlayerCreateCommand : IRequest<bool>
{
    public string NickName { get; set; }

    public long HoursCount { get; set; }

    public long ComputerId { get; set; }
}