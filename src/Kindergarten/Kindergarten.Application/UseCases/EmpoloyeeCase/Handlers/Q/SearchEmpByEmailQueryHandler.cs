using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;
using Kindergarten.Domain.Entities.Employees;
using MediatR;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Handlers.Q;

public class SearchEmpByEmailQueryHandler : IRequestHandler<SearchEmpByEmailQuery, IQueryable<Employee>>
{
    private readonly IAppDbContext _context;

    public SearchEmpByEmailQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Employee>> Handle(SearchEmpByEmailQuery request,
        CancellationToken cancellationToken)
    {
        var result = _context.Employees
            .Where(x => x.Email.ToLower()
            .Contains(request.Email.ToLower()));

        return result;
    }
}
