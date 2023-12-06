using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.TeacherCase.Queries;
using Kindergarten.Domain.Entities.Teachers;
using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Handlers.Q;

public class SearchTeacherByFullNameQueryHandler :
    IRequestHandler<SearchTeacherByFullNameQuery, IQueryable<Teacher>>
{
    private readonly IAppDbContext _context;

    public SearchTeacherByFullNameQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Teacher>> Handle(SearchTeacherByFullNameQuery request,
        CancellationToken cancellationToken)
    {
        var result = _context.Teachers
           .Where(x => x.FullName.ToLower()
           .Contains(request.FullName.ToLower()));

        return result;
    }
}
