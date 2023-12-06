using Kindergarten.Domain.Entities.Parents;
using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Queries;

public class SearchParentByPhoneNumberQuery : IRequest<IQueryable<Parent>>
{
    public string PhoneNumber { get; set; }
}