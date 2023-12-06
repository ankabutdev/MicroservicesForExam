using Kindergarten.Domain.Entities.Admins;
using MediatR;

namespace Kindergarten.Application.UseCases.AdminCase.Queries;

public class GetByIdAdminQuery : IRequest<Admin>
{
    public long Id { get; set; }
}
