using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Commands;

public class HistoryDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
