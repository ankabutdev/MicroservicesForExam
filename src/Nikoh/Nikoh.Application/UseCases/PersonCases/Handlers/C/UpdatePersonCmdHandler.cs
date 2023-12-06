using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.PersonCases.Commands;

namespace Nikoh.Application.UseCases.PersonCases.Handlers.C;

public class UpdatePersonCmdHandler : IRequestHandler<UpdatePersonCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdatePersonCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdatePersonCmd request,
        CancellationToken cancellationToken)
    {
        try
        {
            var people = await _context.People
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (people is null)
                throw new ArgumentNullException(nameof(people));

            _mapper.Map(request, people);

            _context.People.Update(people);

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
