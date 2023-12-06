using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.MarriageCases.Queris;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.Application.UseCases.MarriageCases.Handlers.Q;

public class GetAllMarriageQueryHandler :
    IRequestHandler<GetAllMarriageQuery, IEnumerable<Marriage>>
{
    private readonly IAppDbContext _context;

    public GetAllMarriageQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Marriage>> Handle(GetAllMarriageQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Marriages.ToListAsync(cancellationToken);
    }
}
