using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.ParentCase.Queries;
using Kindergarten.Domain.Entities.Parents;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.ParentCase.Handlers.Q;

public class GetAllParentQueryHandler : IRequestHandler<GetAllParentQuery, IEnumerable<Parent>>
{
    private readonly IAppDbContext _context;

    public GetAllParentQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Parent>> Handle(GetAllParentQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Parents.ToListAsync(cancellationToken);
    }
}
