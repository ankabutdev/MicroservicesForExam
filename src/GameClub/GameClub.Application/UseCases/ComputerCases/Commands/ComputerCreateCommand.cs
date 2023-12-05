using MediatR;

namespace GameClub.Application.UseCases.ComputerCases.Commands;

public class ComputerCreateCommand : IRequest<bool>
{
    public string Name { get; set; }

    public string Version { get; set; }

    public double PriceOfHour { get; set; }

}
