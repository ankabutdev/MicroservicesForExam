using MediatR;

namespace GameClub.Application.UseCases.Admin.Commands;

public class CreateAdminCommand : IRequest
{
    public string Name { get; set; }

    public string Password { get; set; }
}
