using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using Kindergarten.Domain.Entities.Parents;
using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Handlers.C;

public class CreateParentCmdHandler : IRequestHandler<CreateParentCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateParentCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateParentCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Parent>(request);

            await _context.Parents.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
