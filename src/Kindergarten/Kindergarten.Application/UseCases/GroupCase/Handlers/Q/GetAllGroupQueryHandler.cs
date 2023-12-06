using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.GroupCase.Queries;
using Kindergarten.Domain.Entities.Groups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.GroupCase.Handlers.Q;

public class GetAllGroupQueryHandler : IRequestHandler<GetAllGroupQuery, IEnumerable<Group>>
{
    private readonly IAppDbContext _context;

    public GetAllGroupQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Group>> Handle(GetAllGroupQuery request, CancellationToken cancellationToken)
    {
        return await _context.Groups.ToListAsync(cancellationToken);
    }
}
