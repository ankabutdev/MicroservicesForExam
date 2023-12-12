using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    private readonly IAppDbContext _context;

    public GetAllUsersQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Users
            .Include(x => x.Announcements)
            .ToListAsync(cancellationToken);
    }
}
