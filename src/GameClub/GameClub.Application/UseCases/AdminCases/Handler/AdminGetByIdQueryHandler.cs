using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Queries;
using GameClub.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class AdminGetByIdQueryHandler : IRequestHandler<AdminGetByIdQuery, Admin>
{
    private readonly IApplicationDbContext _context;

    public AdminGetByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Admin> Handle(AdminGetByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? new Admin();
    }
}
