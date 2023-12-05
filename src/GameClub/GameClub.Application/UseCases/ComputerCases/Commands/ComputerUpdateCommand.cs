using MediatR;

namespace GameClub.Application.UseCases.ComputerCases.Commands;

public class ComputerUpdateCommand : IRequest<bool>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

}
