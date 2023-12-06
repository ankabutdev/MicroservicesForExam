using Kindergarten.Domain.Entities.Employees;
using MediatR;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Queries;

public class GetByIdEmpQuery : IRequest<Employee>
{
    public long Id { get; set; }
}
