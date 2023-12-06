using Kindergarten.Domain.Entities.Admins;
using MediatR;

namespace Kindergarten.Application.UseCases.AdminCase.Queries;

public class GetAllAdminQuery : IRequest<IEnumerable<Admin>>
{
}
