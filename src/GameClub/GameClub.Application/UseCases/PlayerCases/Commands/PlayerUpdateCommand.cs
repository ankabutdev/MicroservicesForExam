using MediatR;

namespace GameClub.Application.UseCases.PlayerCases.Commands;

public class PlayerUpdateCommand : IRequest<bool>
{
    public string NickName { get; set; }

    public long HoursCount { get; set; }
}
