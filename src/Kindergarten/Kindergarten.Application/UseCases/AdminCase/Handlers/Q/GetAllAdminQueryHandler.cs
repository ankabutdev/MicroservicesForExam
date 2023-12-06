using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.AdminCase.Queries;
using Kindergarten.Domain.Entities.Admins;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.AdminCase.Handlers.Q;

public class GetAllAdminQueryHandler : IRequestHandler<GetAllAdminQuery, IEnumerable<Admin>>
{
    private readonly IAppDbContext _context;

    public GetAllAdminQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Admin>> Handle(GetAllAdminQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Admins.ToListAsync(cancellationToken);
    }
}
