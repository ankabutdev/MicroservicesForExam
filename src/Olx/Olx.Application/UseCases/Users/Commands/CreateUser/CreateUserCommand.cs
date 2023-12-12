using MediatR;
using Olx.Domain.Enums;

namespace Olx.Application.UseCases.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<bool>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string UserName { get; set; }

    public string Address { get; set; }

    public Role Role { get; set; }

}
