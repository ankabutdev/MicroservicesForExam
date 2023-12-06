using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.StudentCase.Queries;
using Kindergarten.Domain.Entities.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.StudentCase.Handlers.Q;

public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<Student>>
{
    private readonly IAppDbContext _context;

    public GetAllStudentQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Student>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
    {
        return await _context.Students.ToListAsync(cancellationToken);
    }
}
