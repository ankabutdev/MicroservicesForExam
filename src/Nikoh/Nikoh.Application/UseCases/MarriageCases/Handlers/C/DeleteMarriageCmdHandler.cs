using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.MarriageCases.Commands;

namespace Nikoh.Application.UseCases.MarriageCases.Handlers.C;

public class DeleteMarriageCmdHandler : IRequestHandler<DeleteMarriageCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteMarriageCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteMarriageCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var marriage = await _context.Marriages
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (marriage == null)
            return false;

        _context.Marriages.Remove(marriage);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
