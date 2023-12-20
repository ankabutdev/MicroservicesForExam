using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.C;

public class DeleteEmpCmdHandler : IRequestHandler<EmpDeleteCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteEmpCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(EmpDeleteCmd request,
        CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var emp = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (emp == null)
            return false;

        _context.Employees.Remove(emp);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
