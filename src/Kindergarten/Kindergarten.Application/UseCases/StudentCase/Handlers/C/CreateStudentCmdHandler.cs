using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.StudentCase.Commands;
using Kindergarten.Domain.Entities.Students;
using MediatR;

namespace Kindergarten.Application.UseCases.StudentCase.Handlers.C;

public class CreateStudentCmdHandler : IRequestHandler<CreateStudentCmd, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateStudentCmdHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateStudentCmd request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Student>(request);

            await _context.Students.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
