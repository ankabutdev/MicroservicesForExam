using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.StudentCase.Queries;
using Kindergarten.Domain.Entities.Students;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.StudentCase.Handlers.Q;

public class GetByStudentIdQueryHandler : IRequestHandler<GetByIdStudentQuery, Student>
{
    private readonly IAppDbContext _context;

    public GetByStudentIdQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Student> Handle(GetByIdStudentQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Students
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Student not found!");
    }
}
