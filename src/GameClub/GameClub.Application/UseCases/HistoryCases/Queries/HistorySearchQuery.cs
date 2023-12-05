using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Queries;

public class HistorySearchQuery : IRequest<IQueryable<History>>
{
    public string Message { get; set; }
}
