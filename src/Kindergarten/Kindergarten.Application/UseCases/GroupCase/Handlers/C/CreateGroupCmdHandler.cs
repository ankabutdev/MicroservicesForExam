using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using Kindergarten.Domain.Entities.Groups;
using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Handlers.C;

public class CreateGroupCmdHandler : IRequestHandler<CreateGroupCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateGroupCmdHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateGroupCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Group>(request);

            await _context.Groups.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
