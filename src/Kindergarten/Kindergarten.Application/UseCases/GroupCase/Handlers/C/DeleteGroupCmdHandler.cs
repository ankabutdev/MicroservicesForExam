using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.GroupCase.Handlers.C;

public class DeleteGroupCmdHandler : IRequestHandler<DeleteGroupCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteGroupCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteGroupCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var emp = await _context.Groups
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (emp == null)
            return false;
        _context.Groups.Remove(emp);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
