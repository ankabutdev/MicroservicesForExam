using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.GroupCase.Queries;
using Kindergarten.Domain.Entities.Groups;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.GroupCase.Handlers.Q;

public class GetByIdGroupQueryHandler : IRequestHandler<GetByIdGroupQuery, Group>
{
    private readonly IAppDbContext _context;

    public GetByIdGroupQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Group> Handle(GetByIdGroupQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Groups
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Group not found!");
    }
}
