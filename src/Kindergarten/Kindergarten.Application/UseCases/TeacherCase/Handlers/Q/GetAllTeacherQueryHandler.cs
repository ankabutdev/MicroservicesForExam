using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.TeacherCase.Queries;
using Kindergarten.Domain.Entities.Teachers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.TeacherCase.Handlers.Q;

public class GetAllTeacherQueryHandler :
    IRequestHandler<GetAllTeacherQuery, IEnumerable<Teacher>>
{
    private readonly IAppDbContext _context;

    public GetAllTeacherQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Teacher>> Handle(GetAllTeacherQuery request,
        CancellationToken cancellationToken)
    {
        return await _context.Teachers
            .Include(x => x.Groups)
            .ToListAsync(cancellationToken);
    }
}
