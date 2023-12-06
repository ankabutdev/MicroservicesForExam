using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.PersonCases.Commands;

namespace Nikoh.Application.UseCases.PersonCases.Handlers.C;

public class DeletePersonCmdHandler : IRequestHandler<DeletePersonCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeletePersonCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeletePersonCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var people = await _context.People
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (people == null)
            return false;

        _context.People.Remove(people);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
