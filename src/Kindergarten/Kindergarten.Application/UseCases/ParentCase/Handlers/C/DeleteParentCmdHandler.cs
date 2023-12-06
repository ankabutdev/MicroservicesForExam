using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.ParentCase.Handlers.C;

public class DeleteParentCmdHandler : IRequestHandler<DeleteParentCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteParentCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteParentCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var parent = await _context.Parents
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (parent == null)
            return false;
        _context.Parents.Remove(parent);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
