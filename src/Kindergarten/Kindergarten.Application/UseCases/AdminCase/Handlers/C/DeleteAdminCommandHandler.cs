using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.AdminCase.Handlers.C;

public class AdminDeleteCommandHandler : IRequestHandler<DeleteAdminCommand, bool>
{
    private readonly IAppDbContext _context;

    public AdminDeleteCommandHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var admin = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (admin == null)
            return false;

        _context.Admins.Remove(admin);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
