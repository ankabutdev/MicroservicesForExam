using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class UpdateAdminCommandHandler : AsyncRequestHandler<UpdateAdminCommand>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAdminCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    protected override async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = _context.Admins
            .FirstOrDefault(x => x.Id == request.Id);

        if (admin is null)
            throw new ArgumentNullException(nameof(admin));

        _mapper.Map(request, admin);

        _context.Admins.Update(admin);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
