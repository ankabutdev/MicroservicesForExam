using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.TeacherCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.TeacherCase.Handlers.C;

public class DeleteTeacherCmdHandler : IRequestHandler<DeleteTeacherCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteTeacherCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteTeacherCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var teacher = await _context.Teachers
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (teacher == null)
            return false;
        _context.Teachers.Remove(teacher);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
