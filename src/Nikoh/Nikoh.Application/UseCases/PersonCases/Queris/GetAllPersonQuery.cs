using MediatR;
using NIkoh.Domain.Entities.Persons;

namespace Nikoh.Application.UseCases.PersonCases.Queris;

public class GetAllPersonQuery : IRequest<IEnumerable<Person>>
{
}
