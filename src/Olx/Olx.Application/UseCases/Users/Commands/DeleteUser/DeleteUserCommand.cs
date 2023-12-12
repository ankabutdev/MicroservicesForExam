using MediatR;

namespace Olx.Application.UseCases.Users.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<bool>
{
    public long Id { get; set; }
}
