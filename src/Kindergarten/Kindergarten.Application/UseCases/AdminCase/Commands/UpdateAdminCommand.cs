using MediatR;

namespace Kindergarten.Application.UseCases.AdminCases.Commands;

public class UpdateAdminCommand : IRequest<bool>
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}