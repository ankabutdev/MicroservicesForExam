using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.RequirementCases.Commands;

namespace Nikoh.Application.UseCases.RequirementCases.Handlers.C;

public class DeleteReqCmdHandler : IRequestHandler<DeleteReqCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteReqCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteReqCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var req = await _context.Requirements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (req == null)
            return false;

        _context.Requirements.Remove(req);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
