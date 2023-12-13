using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Olx.Application.Abstractions;

namespace Olx.Application.UseCases.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public UpdateUserCommandHandler(IMapper mapper, IAppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _context.Users
            .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (user is null)
                throw new ArgumentNullException(nameof(user));

            _mapper.Map(request, user);

            _context.Users.Update(user);

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
