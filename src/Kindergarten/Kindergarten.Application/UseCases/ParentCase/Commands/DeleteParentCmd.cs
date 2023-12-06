using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Commands;

public class DeleteParentCmd : IRequest<bool>
{
    public long Id { get; set; }
}
