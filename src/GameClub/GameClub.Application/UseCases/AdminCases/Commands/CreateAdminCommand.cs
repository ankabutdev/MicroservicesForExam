using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Commands;

public class CreateAdminCommand : IRequest<bool>
{
    public string Name { get; set; }

    public string Password { get; set; }
}
