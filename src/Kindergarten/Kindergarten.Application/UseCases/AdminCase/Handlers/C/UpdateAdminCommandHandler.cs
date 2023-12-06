using AutoMapper;
using Kindergarten.Application.Abstractions;
using Kindergarten.Application.UseCases.AdminCases.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kindergarten.Application.UseCases.AdminCase.Handlers.C;

public class UpdateAdminCommandHandler : IRequestHandler<UpdateAdminCommand, bool>
{
    private readonly IAppDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAdminCommandHandler(IAppDbContext context,
        IMapper mapper)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<bool> Handle(UpdateAdminCommand request,
        CancellationToken cancellationToken)
    {
        try
        {
            var admin = await _context.Admins
            .FirstOrDefaultAsync(x => x.Id == request.Id);

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