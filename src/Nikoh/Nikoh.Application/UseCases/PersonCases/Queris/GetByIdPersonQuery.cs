using MediatR;
using NIkoh.Domain.Entities.Persons;

namespace Nikoh.Application.UseCases.PersonCases.Queris;

public class GetByIdPersonQuery : IRequest<Person>
{
    public long Id { get; set; }
}
