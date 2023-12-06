using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.MarriageCases.Queris;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.Application.UseCases.MarriageCases.Handlers.Q;

public class GetByIdMarriageQueryHandler : IRequestHandler<GetByIdMarriageQuery, Marriage>
{
    private readonly IAppDbContext _context;

    public GetByIdMarriageQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Marriage> Handle(GetByIdMarriageQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Marriages
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Marriage not found!");
    }
}
