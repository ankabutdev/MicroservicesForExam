using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Commands;

public class HistoryCreateCommand : IRequest<bool>
{
    public string Message { get; set; }

    public string Description { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

}
