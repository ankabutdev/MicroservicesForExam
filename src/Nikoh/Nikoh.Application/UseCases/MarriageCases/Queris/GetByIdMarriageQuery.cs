using MediatR;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.Application.UseCases.MarriageCases.Queris;

public class GetByIdMarriageQuery : IRequest<Marriage>
{
    public long Id { get; set; }
}
