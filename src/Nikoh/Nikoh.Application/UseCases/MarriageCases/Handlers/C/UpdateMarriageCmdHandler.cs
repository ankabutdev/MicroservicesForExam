using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.MarriageCases.Commands;

namespace Nikoh.Application.UseCases.MarriageCases.Handlers.C;

public class UpdateMarriageCmdHandler : IRequestHandler<UpdateMarriageCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateMarriageCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateMarriageCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var marriage = await _context.Marriages
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (marriage is null)
                throw new ArgumentNullException(nameof(marriage));

            _mapper.Map(request, marriage);

            _context.Marriages.Update(marriage);

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
