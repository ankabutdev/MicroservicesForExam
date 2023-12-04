using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class CreateAdminCommandHandler : IRequestHandler<CreateAdminCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateAdminCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = _mapper.Map<Admin>(request);

            await _context.Admins.AddAsync(entity);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
