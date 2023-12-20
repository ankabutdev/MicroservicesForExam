using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.C;

public class UpdateEmpCmdHandler : IRequestHandler<EmpUpdateCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateEmpCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(EmpUpdateCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var emp = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (emp is null)
                throw new ArgumentNullException(nameof(emp));

            _mapper.Map(request, emp);

            _context.Employees.Update(emp);

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
