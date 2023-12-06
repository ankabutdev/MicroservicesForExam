using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.GroupCase.Queries;
using Kindergarten.Domain.Entities.Groups;
using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Handlers.Q;

public class SerachByGroupNameQueryHandler : IRequestHandler<SearchByGroupNameQuery, IQueryable<Group>>
{
    private readonly IAppDbContext _context;

    public SerachByGroupNameQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Group>> Handle(SearchByGroupNameQuery request,
        CancellationToken cancellationToken)
    {
        var result = _context.Groups
            .Where(x => x.Name.ToLower()
            .Contains(request.Name.ToLower()));

        return result;
    }
}
