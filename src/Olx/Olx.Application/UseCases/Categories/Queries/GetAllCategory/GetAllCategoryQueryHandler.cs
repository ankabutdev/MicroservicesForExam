using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Categories.Queries.GetAllCategory;

public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<Category>>
{
    private readonly IAppDbContext _context;

    public GetAllCategoryQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
    {
        return await _context
            .Categories
            .Include(x => x.Announcements)
            .ToListAsync(cancellationToken);
    }
}
