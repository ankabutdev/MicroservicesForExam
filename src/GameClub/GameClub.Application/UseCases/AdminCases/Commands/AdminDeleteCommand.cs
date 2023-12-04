using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Commands;

public class AdminDeleteCommand : IRequest<bool>
{
    public long Id { get; set; }
}
