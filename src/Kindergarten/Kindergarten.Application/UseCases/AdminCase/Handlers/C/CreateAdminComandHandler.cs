using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using Kindergarten.Domain.Entities.Admins;
using MediatR;

namespace Kindergarten.Application.UseCases.AdminCase.Handlers.C;

public class CreateAdminComandHandler : IRequestHandler<CreateAdminCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public CreateAdminComandHandler(IAppDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateAdminCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Admin>(request);

            await _context.Admins.AddAsync(entity);
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
