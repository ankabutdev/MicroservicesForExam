using MediatR;

namespace Kindergarten.Application.UseCases.EmpoloyeeCase.Commands;

public class EmpDeleteCmd : IRequest<bool>
{
    public long Id { get; set; }
}
