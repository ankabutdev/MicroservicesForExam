using MediatR;
using System.Text.Json.Serialization;

namespace GameClub.Application.UseCases.PlayerCases.Commands;

public class PlayerUpdateCommand : IRequest<bool>
{
    [JsonIgnore]
    public long Id { get; set; }

    public string NickName { get; set; }

    public long HoursCount { get; set; }
}
