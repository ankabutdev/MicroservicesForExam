using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.TeacherCase.Commands;
using Kindergarten.Domain.Entities.Teachers;
using MediatR;

namespace Kindergarten.Application.UseCases.TeacherCase.Handlers.C;

public class CreateTeacherCmdHandler : IRequestHandler<CreateTeacherCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateTeacherCmdHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateTeacherCmd request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Teacher>(request);

            await _context.Teachers.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
