using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.AdminCase.Queries;
using Kindergarten.Domain.Entities.Admins;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.AdminCase.Handlers.Q;

public class AdminGetByIdQueryHandler : IRequestHandler<GetByIdAdminQuery, Admin>
{
    private readonly IAppDbContext _context;

    public AdminGetByIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Admin> Handle(GetByIdAdminQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Admin not found!");
    }
}

