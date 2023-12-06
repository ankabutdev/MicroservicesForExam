using AutoMapper;
using MediatR;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.MarriageCases.Commands;
using NIkoh.Domain.Entities.Marriages;

namespace Nikoh.Application.UseCases.MarriageCases.Handlers.C;

public class CreateMarriageCmdHandler : IRequestHandler<CreateMarriageCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateMarriageCmdHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateMarriageCmd request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Marriage>(request);

            await _context.Marriages.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
