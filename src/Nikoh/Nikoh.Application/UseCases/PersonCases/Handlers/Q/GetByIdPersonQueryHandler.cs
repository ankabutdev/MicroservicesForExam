using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.PersonCases.Queris;
using NIkoh.Domain.Entities.Persons;

namespace Nikoh.Application.UseCases.PersonCases.Handlers.Q;

public class GetByIdPersonQueryHandler : IRequestHandler<GetByIdPersonQuery, Person>
{
    private readonly IAppDbContext _context;

    public GetByIdPersonQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Person> Handle(GetByIdPersonQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _context.People
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Person not found!");
    }
}
