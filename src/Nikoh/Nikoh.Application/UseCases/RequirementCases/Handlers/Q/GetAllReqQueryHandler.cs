using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.RequirementCases.Queris;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.UseCases.RequirementCases.Handlers.Q;

public class GetAllReqQueryHandler : IRequestHandler<GetAllReqQuery, IEnumerable<Requirement>>
{
    private readonly IAppDbContext _context;

    public GetAllReqQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Requirement>> Handle(GetAllReqQuery request, CancellationToken cancellationToken)
    {
        return await _context.Requirements.ToListAsync(cancellationToken);
    }
}
