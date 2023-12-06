using MediatR;

namespace Kindergarten.Application.UseCases.GroupCase.Commands;

public class DeleteGroupCmd : IRequest<bool>
{
    public long Id { get; set; }
}
