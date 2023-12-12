using MediatR;
using Olx.Domain.Entities;

namespace Olx.Application.UseCases.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<User>>
{
}
