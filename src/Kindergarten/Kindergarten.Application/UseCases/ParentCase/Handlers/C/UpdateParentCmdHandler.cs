using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.ParentCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.ParentCase.Handlers.C;

public class UpdateParentCmdHandler : IRequestHandler<UpdateParentCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateParentCmdHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateParentCmd request,
        CancellationToken cancellationToken)
    {
        try
        {
            var parent = await _context.Parents
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (parent is null)
                throw new ArgumentNullException(nameof(parent));

            _mapper.Map(request, parent);

            _context.Parents.Update(parent);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
