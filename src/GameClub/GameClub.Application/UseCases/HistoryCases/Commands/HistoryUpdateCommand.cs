using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Commands;

public class HistoryUpdateCommand : IRequest<bool>
{
    public long Id { get; set; }

    public string Message { get; set; }

    public string Description { get; set; }
}
