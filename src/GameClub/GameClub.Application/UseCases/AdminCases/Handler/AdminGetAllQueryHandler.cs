using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class AdminGetAllQueryHandler : IRequestHandler<AdminGetAllQuery, IEnumerable<Admin>>
{
    private readonly IApplicationDbContext _context;

    public AdminGetAllQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Admin>> Handle(AdminGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Admins.ToListAsync(cancellationToken);
    }
}
