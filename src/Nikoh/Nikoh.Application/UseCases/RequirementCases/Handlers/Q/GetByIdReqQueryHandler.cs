using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.RequirementCases.Queris;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.UseCases.RequirementCases.Handlers.Q;

public class GetByIdReqQueryHandler : IRequestHandler<GetByIdReqQuery, Requirement>
{
    private readonly IAppDbContext _context;

    public GetByIdReqQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Requirement> Handle(GetByIdReqQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Requirements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Requirement not found!");
    }
}
