using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.PersonCases.Queris;
using NIkoh.Domain.Entities.Persons;

namespace Nikoh.Application.UseCases.PersonCases.Handlers.Q;

public class GetAllPersonQueryHandler :
    IRequestHandler<GetAllPersonQuery, IEnumerable<Person>>
{
    private readonly IAppDbContext _context;

    public GetAllPersonQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Person>> Handle(GetAllPersonQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.People.ToListAsync(cancellationToken);
    }
}
