using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class AdminDeleteCommandHandler : IRequestHandler<AdminDeleteCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public AdminDeleteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AdminDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var admin = await _context.Admins.FirstOrDefaultAsync(x => x.Id == request.Id);

        if (admin == null)
            return false;

        _context.Admins.Remove(admin);

        var result = await _context.SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
