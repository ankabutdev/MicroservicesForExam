using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;
using Kindergarten.Domain.Entities.Employees;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.Q;

public class GetAllEmpQueryHandler : IRequestHandler<GetAllEmpQuery, IEnumerable<Employee>>
{
    private readonly IAppDbContext _context;

    public GetAllEmpQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Employee>> Handle(GetAllEmpQuery request, CancellationToken cancellationToken)
    {
        return await _context.Employees.ToListAsync(cancellationToken);
    }
}
