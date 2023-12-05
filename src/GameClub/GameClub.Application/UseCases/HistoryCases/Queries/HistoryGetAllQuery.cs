using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.HistoryCases.Queries;

public class HistoryGetAllQuery : IRequest<IEnumerable<History>>
{
}
