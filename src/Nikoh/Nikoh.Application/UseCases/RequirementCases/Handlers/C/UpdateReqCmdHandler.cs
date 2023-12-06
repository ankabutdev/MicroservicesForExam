using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.RequirementCases.Commands;

namespace Nikoh.Application.UseCases.RequirementCases.Handlers.C;

public class UpdateReqCmdHandler : IRequestHandler<UpdateReqCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateReqCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateReqCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var req = await _context.Requirements
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (req is null)
                throw new ArgumentNullException(nameof(req));

            _mapper.Map(request, req);

            _context.Requirements.Update(req);

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
