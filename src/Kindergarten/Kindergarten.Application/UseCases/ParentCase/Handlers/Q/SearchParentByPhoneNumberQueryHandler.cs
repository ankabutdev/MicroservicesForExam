using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.ParentCase.Queries;
using Kindergarten.Domain.Entities.Parents;
using MediatR;

namespace Kindergarten.Application.UseCases.ParentCase.Handlers.Q;

public class SearchParentByPhoneNumberQueryHandler :
    IRequestHandler<SearchParentByPhoneNumberQuery, IQueryable<Parent>>
{
    private readonly IAppDbContext _context;

    public SearchParentByPhoneNumberQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Parent>> Handle(SearchParentByPhoneNumberQuery request,
        CancellationToken cancellationToken)
    {
        var result = _context.Parents
            .Where(x => x.PhoneNumber.ToLower()
            .Contains(request.PhoneNumber.ToLower()));

        return result;
    }
}
