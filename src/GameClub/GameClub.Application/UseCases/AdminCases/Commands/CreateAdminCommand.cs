using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Commands;

public class CreateAdminCommand : IRequest
{
    public string Name { get; set; }

    public string Password { get; set; }
}
