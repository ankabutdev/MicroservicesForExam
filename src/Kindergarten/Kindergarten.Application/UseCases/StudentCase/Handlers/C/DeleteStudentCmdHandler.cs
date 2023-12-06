using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.StudentCase.Handlers.C;

public class DeleteStudentCmdHandler : IRequestHandler<DeleteStudentCmd, bool>
{
    private readonly IAppDbContext _context;

    public DeleteStudentCmdHandler(IAppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteStudentCmd request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            return false;

        var student = await _context.Students
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (student == null)
            return false;
        _context.Students.Remove(student);

        var result = await _context
            .SaveChangesAsync(cancellationToken);

        return result > 0;
    }
}
