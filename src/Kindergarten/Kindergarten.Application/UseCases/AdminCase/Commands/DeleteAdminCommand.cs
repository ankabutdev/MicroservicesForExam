using MediatR;

namespace Kindergarten.Application.UseCases.AdminCases.Commands;

public class DeleteAdminCommand : IRequest<bool>
{
    public long Id { get; set; }
}
