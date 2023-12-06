using Kindergarten.Domain.Entities.Employees;
using MediatR;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;

public class SearchEmpByEmailQuery : IRequest<IQueryable<Employee>>
{
    public string Email { get; set; }
}
