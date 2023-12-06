using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;
using Kindergarten.Domain.Entities.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.Q;

public class GetByIdEmpQueryHandler : IRequestHandler<GetByIdEmpQuery, Employee>
{
    private readonly IAppDbContext _context;

    public GetByIdEmpQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> Handle(GetByIdEmpQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Employees
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Employee not found!");
    }
}
