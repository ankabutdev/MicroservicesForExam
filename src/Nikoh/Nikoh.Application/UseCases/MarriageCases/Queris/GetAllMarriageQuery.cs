using MediatR;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.Application.UseCases.MarriageCases.Queris;

public class GetAllMarriageQuery : IRequest<IEnumerable<Marriage>>
{
}
