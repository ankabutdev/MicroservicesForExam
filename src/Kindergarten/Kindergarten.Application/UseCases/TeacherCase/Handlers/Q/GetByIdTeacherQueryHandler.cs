using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.TeacherCase.Queries;
using Kindergarten.Domain.Entities.Teachers;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.TeacherCase.Handlers.Q;

public class GetByIdTeacherQueryHandler : IRequestHandler<GetByIdTeacherQuery, Teacher>
{
    private readonly IAppDbContext _context;

    public GetByIdTeacherQueryHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<Teacher> Handle(GetByIdTeacherQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Teachers
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return result ?? throw new Exception("Teacher not found!");
    }
}
