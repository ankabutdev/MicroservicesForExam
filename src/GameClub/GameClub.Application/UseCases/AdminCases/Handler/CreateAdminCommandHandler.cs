using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using MediatR;

namespace GameClub.Application.UseCases.Admin.Handler;

public class CreateAdminCommandHandler : AsyncRequestHandler<CreateAdminCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateAdminCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    protected override async Task Handle(CreateAdminCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Admin()
        {
            Name = request.Name,
            Password = request.Password,
        };

        await _context.Admins.AddAsync(entity);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
