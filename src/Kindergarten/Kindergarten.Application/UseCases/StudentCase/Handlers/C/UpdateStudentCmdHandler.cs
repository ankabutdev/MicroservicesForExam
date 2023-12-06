using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.StudentCase.Handlers.C;

public class UpdateStudentCmdHandler : IRequestHandler<UpdateStudentCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateStudentCmdHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateStudentCmd request,
        CancellationToken cancellationToken)
    {
        try
        {
            var student = await _context.Students
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (student is null)
                throw new ArgumentNullException(nameof(student));

            _mapper.Map(request, student);

            _context.Students.Update(student);

            var result = await _context
                .SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
