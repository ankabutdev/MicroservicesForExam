using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.GroupCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.GroupCase.Handlers.C;

public class UpdateGroupCmdHandler : IRequestHandler<UpdateGroupCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateGroupCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateGroupCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var group = await _context.Groups
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (group is null)
                throw new ArgumentNullException(nameof(group));

            _mapper.Map(request, group);

            _context.Groups.Update(group);

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
