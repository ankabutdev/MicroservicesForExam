using MediatR;

namespace Kindergarten.Application.UseCases.AdminCases.Commands;

public class CreateAdminCommand : IRequest<bool>
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}
