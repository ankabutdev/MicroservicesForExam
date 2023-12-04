using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using GameClub.Domain.Entities;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class CreateAdminCommandHandler : AsyncRequestHandler<CreateAdminCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateAdminCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    protected override async Task Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Admin>(request);

        await _context.Admins.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
