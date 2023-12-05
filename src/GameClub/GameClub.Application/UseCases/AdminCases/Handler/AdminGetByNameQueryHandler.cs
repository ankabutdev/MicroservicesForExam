using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Queries;
using GameClub.Domain.Entities;
using GameClub.Domain.Exceptions.Admins;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class AdminGetByNameQueryHandler : IRequestHandler<AdminGetByNameQuery, Admin>
{
    private readonly IApplicationDbContext _context;

    public AdminGetByNameQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Admin> Handle(AdminGetByNameQuery request, CancellationToken cancellationToken)
    {
        var admin = await _context.Admins
            .FirstOrDefaultAsync(x => x.Name == request.Name,
            cancellationToken);

        if (admin is null)
            throw new AdminNotFoundException();

        return admin;
    }
}
