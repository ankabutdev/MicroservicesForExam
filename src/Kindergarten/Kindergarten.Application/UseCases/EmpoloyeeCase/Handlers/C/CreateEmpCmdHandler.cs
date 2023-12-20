using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using Kindergarten.Domain.Entities.Employees;
using MediatR;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.C;

public class CreateEmpCmdHandler : IRequestHandler<EmpCreateCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateEmpCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EmpCreateCmd request, CancellationToken cancellationToken)
    {
        try
        {
            Employee? entity = _mapper.Map<Employee>(request);

            if (entity is null)
                return false;

            await _context.Employees.AddAsync(entity, cancellationToken);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
