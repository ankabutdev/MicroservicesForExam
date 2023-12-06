using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.TeacherCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.TeacherCase.Handlers.C;

public class UpdateTeacherCmdHandler : IRequestHandler<UpdateTeacherCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateTeacherCmdHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateTeacherCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var teacher = await _context.Teachers
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (teacher is null)
                throw new ArgumentNullException(nameof(teacher));

            _mapper.Map(request, teacher);

            _context.Teachers.Update(teacher);

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
