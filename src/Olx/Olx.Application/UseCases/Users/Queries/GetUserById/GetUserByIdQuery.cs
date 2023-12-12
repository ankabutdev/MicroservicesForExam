using MediatR;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<User>
{
    public long Id { get; set; }
}
