using AutoMapper;
using GameClub.Application.Abstractions;
using GameClub.Application.UseCases.AdminCases.Commands;
using MediatR;

namespace GameClub.Application.UseCases.AdminCases.Handler;

public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAdminCommandHandler(IApplicationDbContext context,
        IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<bool> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var admin = _context.Admins
            .FirstOrDefault(x => x.Id == request.Id);

            if (admin is null)
                throw new ArgumentNullException(nameof(admin));

            _mapper.Map(request, admin);

            _context.Admins.Update(admin);
            var result = await _context.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}
