using AutoMapper;
using MediatR;
using Nikoh.Application.Abstractions;
using Nikoh.Application.UseCases.PersonCases.Commands;
using NIkoh.Domain.Entities.Persons;

namespace Nikoh.Application.UseCases.PersonCases.Handlers.C;

public class CreatePersonCmdHandler : IRequestHandler<CreatePersonCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreatePersonCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreatePersonCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Person>(request);

            await _context.People.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
