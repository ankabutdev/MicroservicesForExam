using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.StudentCase.Queries;
using Kindergarten.Domain.Entities.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.StudentCase.Handlers.Q;

public class SearchStudentByFullNameQueryHandler :
    IRequestHandler<SearchStudentByFullNameQuery, IQueryable<Student>>
{
    private readonly IAppDbContext _context;

    public SearchStudentByFullNameQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IQueryable<Student>> Handle(SearchStudentByFullNameQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Students
            .Where(x => x.FullName.ToLower()
            .Contains(request.FullName.ToLower()));

        return result;
    }
}
