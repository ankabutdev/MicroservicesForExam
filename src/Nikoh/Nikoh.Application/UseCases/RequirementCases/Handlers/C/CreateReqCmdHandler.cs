using AutoMapper;
using MediatR;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.RequirementCases.Commands;
using NIkoh.Domain.Entities.Requirements;

namespace Nikoh.Application.UseCases.RequirementCases.Handlers.C;

public class CreateReqCmdHandler : IRequestHandler<CreateReqCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateReqCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateReqCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Requirement>(request);

            await _context.Requirements.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
